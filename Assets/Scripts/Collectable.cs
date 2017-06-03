using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	bool hideAnimation = false; //?

	protected virtual void onRabitHit(Rabit rabit) { }

	void OnTriggerEnter2D(Collider2D collider) {
		if (!hideAnimation) {
			Rabit rabit = collider.GetComponent<Rabit>();
			if (rabit != null)
				onRabitHit(rabit);
		}
	}

	public void CollectedHide() {
		Destroy(gameObject);
		hideAnimation = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
