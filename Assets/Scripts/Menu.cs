using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public Camera gameCam;
	private List<MenuBtn> btns = new List<MenuBtn> ();
	public int level_menu = 0, level_join = 1, level_select = 2;
	public List<string> clicked =new List<string>();
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Treat this class as a singleton.  This will hold the instance of the class.
	private static Menu instance;
	
	public static Menu Instance {
		get {
			// This should NEVER happen, so we want to know about it if it does 
			if (instance == null) {
				Debug.LogError ("Menu instance does not exist");	
			}
			return instance;	
		}
	}

	void Awake ()
	{
		instance = this; 
	}
	
	// Update is called once per frame
	void Update ()
	{
	   
		string clickBtn = "Fire1";
		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = gameCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit)) {
				foreach (MenuBtn btn in btns) {
					if (btn.getSprite ().gameObject.activeSelf && btn.ColliderTransform == hit.transform) {
						btn.getSprite ().SetSprite (btn.clickedFrameName);
						Debug.Log (btn.getSprite ().name + ":" + btn.clickedFrameName);
					}
				}
			}
		}
		if (Input.GetButtonUp ("Fire1")) {
			foreach (MenuBtn btn in btns) {
					
				btn.getSprite ().SetSprite (btn.orgFrameName);
				Debug.Log (btn.getSprite ().name + ":" + btn.orgFrameName);
             
			}
			
			Ray ray = gameCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit)) {
				foreach (MenuBtn btn in btns) {
					
					if (btn.getSprite ().gameObject.activeSelf && btn.ColliderTransform == hit.transform) {
						switch (btn.getSprite ().name) {
						case "newGameBtn":
							Application.LoadLevel (level_join);
							break;
						case "backToMenuBtn":
							Application.LoadLevel (level_menu);
							break;
						case "toSelectBtn":
							Application.LoadLevel (level_select);
							break;
						default:
							break;
						}
						
					}
				}
			}
		}
	
	
	
	}
		
	public void RegisterBtn (MenuBtn btn)
	{
		btns.Add (btn);
	}
	
	
}
