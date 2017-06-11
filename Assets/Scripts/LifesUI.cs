using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesUI : MonoBehaviour {

	public static LifesUI lifesUI;
	public UI2DSprite life1;
	public UI2DSprite life2;
	public UI2DSprite life3;
	public Sprite lifeUsed;

	//private int lifes = 3;

	private void Awake() {
		lifesUI = this;
	}

	public void OnDeathUI(int lifes) {
		if (lifes == 3) life1.sprite2D = lifeUsed;
		else if (lifes == 2) life2.sprite2D = lifeUsed;
		else life3.sprite2D = lifeUsed;
		--lifes;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
