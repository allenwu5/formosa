using UnityEngine;
using System.Collections;

public class SlideCard : MonoBehaviour
{
	private tk2dSprite sprite;
	private float initY;
	

	// Use this for initialization
	void Start ()
	{
		sprite = GetComponent<tk2dSprite> ();
		
		colliderTransform = sprite.transform;
		
		SlideCardControl.Instance.RegisterCards (this);
		
		{
			initY = sprite.transform.position.y;			
		}
	}
	
	private Transform colliderTransform;

	public Transform ColliderTransform {
		get {
			return colliderTransform;
		}
	}
	
	public tk2dSprite getSprite ()
	{
		return sprite;
	}

	public float getInitY {
		get {
			return this.initY;
		}
	}
}
