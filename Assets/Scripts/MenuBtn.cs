using UnityEngine;
using System.Collections;

public class MenuBtn : MonoBehaviour {
	private tk2dSprite sprite;
	public string orgFrameName, clickedFrameName;
	
	private Transform colliderTransform;

	public Transform ColliderTransform
	{
		get
		{
			return colliderTransform;
		}
	}
	
	// Use this for initialization
	void Start () {
		 sprite = GetComponent<tk2dSprite>();
		
		colliderTransform = sprite.transform;
		
		Menu.Instance.RegisterBtn(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public tk2dSprite getSprite(){
		return sprite;
	}
	
}
