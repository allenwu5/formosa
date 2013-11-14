using UnityEngine;
using System.Collections;

public class SlideCard : MonoBehaviour
{private tk2dSprite sprite;
	
	

	// Use this for initialization
	void Start ()
	{
		sprite = GetComponent<tk2dSprite>();
		
		colliderTransform = sprite.transform;
		
		SlideCardControl.Instance.RegisterCards(this);
	}
	
	private Transform colliderTransform;

	public Transform ColliderTransform
	{
		get
		{
			return colliderTransform;
		}
	}
	
	public tk2dSprite getSprite(){
		return sprite;
	}
}
