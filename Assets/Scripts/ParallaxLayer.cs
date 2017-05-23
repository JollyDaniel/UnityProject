using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour {

	public float slowDown = 0.5f;
	Vector3 lastPosition;

	void Awake () {
		lastPosition = Camera.main.transform.position;
	}

	void LateUpdate () {
		Vector3 newPos = Camera.main.transform.position;
		Vector3 diff = newPos - lastPosition;
		lastPosition = newPos;

		Vector3 myPos = this.transform.position;
		myPos += slowDown * diff;
		this.transform.position = myPos;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
