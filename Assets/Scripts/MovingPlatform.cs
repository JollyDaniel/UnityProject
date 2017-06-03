using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 MoveBy;

	Vector3 pointA;
	Vector3 pointB;

	bool goingToA;
	public float delay = 1.5f;
	float wait;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		pointA = transform.position;
		pointB = pointA + MoveBy;
	}
	
	// Update is called once per frame
	void Update () {
		if (wait > 0) { 
			wait -= Time.deltaTime;
			return;
		}

		Vector3 myPos = transform.position;
		Vector3 targ;

		if (goingToA) targ = pointA;
		else targ = pointB;

		Vector3 destination = targ - myPos;
		destination.z = 0;

		if (isArrived(myPos, targ)) {
			goingToA = !goingToA;
			wait = delay;
		} else {
			float move = this.speed * Time.deltaTime;
			float distance = Vector3.Distance(destination, myPos);

			Vector3 move_vec = destination.normalized * Mathf.Min(move, distance);
			this.transform.position += move_vec;
		}
	}

	bool isArrived(Vector3 pos, Vector3 targ) {
		pos.z = 0;
		targ.z = 0;
		return Vector3.Distance(pos, targ) < 0.02f;
	}
}