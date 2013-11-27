	using UnityEngine;
	using System.Collections.Generic;
	
public class SlideCardControl : MonoBehaviour
{
	public Camera gameCam;
	private List<SlideCard> cards = new List<SlideCard> ();
	private static SlideCardControl instance;

	public static SlideCardControl Instance {
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
		
	// Use this for initialization
	void Start ()
	{
		
	}
				
	// Update is called once per frame
	// Update is called once per frame
	public float speed = 1F;
	Vector3 speed3 = Vector3.zero;

	void FixedUpdate ()
	{
			
		//		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
		//			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
		//			transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		//			Debug.Log ("touchDeltaPosition.x: " + touchDeltaPosition.x);
		//			
		//			float dx = touchDeltaPosition.x;
		//			
		//			
		//				foreach (SlideCard card in cards) {
		//					tk2dSprite s = card.getSprite ();
		//						
		//						s.transform.position=new Vector3(dx+s.transform.position.x, s.transform.position.y, s.transform.position.z);
		//					
		//				}
		//			
		//		}
	
			
		Vector3 mousePos = Input.mousePosition;
			
			
		//speed3.x=speed3.x/1.5F;
		//if(Mathf.Abs(speed3.x)>1F){
		//	transform.position=new Vector3(transform.position.x+speed3.x, transform.position.y, transform.position.z);
		//}
			
		bool isTouch = Input.GetMouseButton (0);
		//		if (isTouch) {//touch screen
		//			
		//			Ray ray = gameCam.ScreenPointToRay (Input.mousePosition);
		//			RaycastHit hit = new RaycastHit ();
		//
		//			if (Physics.Raycast (ray, out hit)) {
		//				//ray who?
		//				float dx = 0;
		//				foreach (SlideCard card in cards) {
		//					tk2dSprite s = card.getSprite ();
		//					if (s.gameObject.activeSelf && card.ColliderTransform == hit.transform) {
		//						//ray me...
		//						dx = mousePos.x - s.transform.position.x;
		//					}
		//				}
		//				foreach (SlideCard card in cards) {
		//					tk2dSprite s = card.getSprite ();
		//						
		//						s.transform.position=new Vector3(dx+s.transform.position.x, s.transform.position.y, s.transform.position.z);
		//					
		//				}
		//			}
		//		}
			
	
	  
		float vx = 0, vy = 0;//speed
		bool mouseMode = true;
		if (mouseMode && Input.GetMouseButton (0)) { //if mouse move
			float vFactor = 50F;
			vx = vFactor * Input.GetAxis ("Mouse X");
			vy = vFactor * Input.GetAxis ("Mouse Y");
		}  
			
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {//if touch move
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			vx = touchDeltaPosition.x;
			vy = touchDeltaPosition.y;
		}
		//}
		//if (isTouch) {//touch screen
		if (vx != 0) {	
			float left = 99999, right = 0, width = 0;
			foreach (SlideCard card in cards) {
				tk2dSprite s = card.getSprite ();
							
				float x = s.transform.position.x;
					
				if (x < left)
					left = x;
				if (x > right) {
					right = x;
					width = s.GetBounds ().size.x;
				}
			}	
			
			if ((vx > 0 && left <= 0) || (vx < 0 && right + width >= Screen.width)) {
						
				foreach (SlideCard card in cards) {
					tk2dSprite s = card.getSprite ();
							
					float newX = vx + s.transform.position.x;
					
					
					s.transform.position = new Vector3 (newX, s.transform.position.y, s.transform.position.z);
				}
			}
		}
		if (vy != 0 && vy < -10f) {//pull down
			
			
			
			Ray ray = gameCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();
		
			if (Physics.Raycast (ray, out hit)) {
			foreach (SlideCard card in cards) {
				tk2dSprite s = card.getSprite ();
							if (s.gameObject.activeSelf && card.ColliderTransform == hit.transform) {
				float newY = vy + s.transform.position.y;
					
					
				s.transform.position = new Vector3 (s.transform.position.x, newY, s.transform.position.z);
					}
			}
			}
		}
		
		{//return to the initY

				//ray who?
				foreach (SlideCard card in cards) {
					tk2dSprite s = card.getSprite ();
				
						float currentY = s.transform.position.y;
						float initY = card.getInitY;
						currentY += (initY - currentY) / 2;
						if(Mathf.Abs(initY - currentY)>1){
							s.transform.position = new Vector3 (s.transform.position.x, currentY, s.transform.position.z);
						}
						
				}

		}
			
			
	}
		
	public void RegisterCards (SlideCard card)
	{
		cards.Add (card);
	}
}
	
