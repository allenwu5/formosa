using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class StoryControl : MonoBehaviour {
	private GameObject rightOne, leftOne, dialogBottom1;
	

	// Use this for initialization
	void Start () {
		//init
		rightOne = GameObject.Find("rightOne");
		leftOne = GameObject.Find("leftOne");
		dialogBottom1 = GameObject.Find("dialogBottom1");

		if (rightOne != null) {
			Vector3 p = rightOne.transform.position;
			p.x = 0;
			HOTween.To(rightOne.transform, 1, "position", p);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

}
