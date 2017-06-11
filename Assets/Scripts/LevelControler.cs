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
	void FixedUpdate () {
		/*if (wait > 0) {
			wait -= Time.deltaTime;
			dying = true;
			return;
		}
		if (dying) { 
			tmp.transform.position = this.startPos;
		}
		dying = false;
*/
	}

	public void setStartPosition (Vector3 pos) {
		this.startPos = pos;
	}

	public void RabitDeath (Rabit rabit) {
		//tmp = rabit;
		LifesUI.lifesUI.OnDeathUI(lifes);
		--lifes;
		rabit.transform.position = this.startPos;
	}

	public int getLifesCount () {
		return lifes;
	}

	public void addCoins(int n) {
		coins += n;
	}

	public void addFruits(int n) {
		fruits += n;
		FruitsUI.fruitsUI.FruitCollect(fruits);
	}

	public void addCrystals(int n) {
		crystals += n;
	}

	public void setBig(bool big) {
		isBig = big;
	}

	//Rabit tmp;
	//float timeToWait = 1f;
	//float wait;
	//bool dying;
	private Vector3 startPos;
	public int lifes = 3;
	public int coins = 0;
	public int fruits = 0;
	//public int fruitsAll = 0;
	public int crystals = 0;
	private bool isBig = false;
}
