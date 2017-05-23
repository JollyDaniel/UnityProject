using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		Rabit rabit = collider.GetComponent<Rabit> ();

		if (rabit != null)
			LevelControler.current.RabitDeath (rabit);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
