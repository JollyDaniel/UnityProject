using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsUI : MonoBehaviour {
	
	public UI2DSprite crystal1;
	public UI2DSprite crystal2;
	public UI2DSprite crystal3;
	public Sprite crystal1_new;
	public Sprite crystal2_new;
	public Sprite crystal3_new;
	public static CrystalsUI crystalsUI;


	private void Awake() {
		crystalsUI = this;
	}

	public void setCrystalCollected(int n) {
		if (n == 1) { crystal1.sprite2D = crystal1_new; }
		else if (n == 2) { crystal2.sprite2D = crystal2_new; }
		else { crystal3.sprite2D = crystal3_new; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
