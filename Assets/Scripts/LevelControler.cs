using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour {

	public static LevelControler current;

	void Awake () {
		current = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setStartPosition (Vector3 pos) {
		this.startPos = pos;
	}

	public void RabitDeath (Rabit rabit) {
		--lifes;
		rabit.transform.position = this.startPos;
	}

	public int getLifesCount () {
		return lifes;
	}

	private Vector3 startPos;
	private int lifes = 3;
}
