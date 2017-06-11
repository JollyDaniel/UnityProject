using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsUI : MonoBehaviour {

	public static FruitsUI fruitsUI;
	public UILabel Text;

	private void Awake() {
		fruitsUI = this;

	}

	// Use this for initialization
	void Start () {
		Text.text = 0 + "/" + 2;
	}

	public void FruitCollect(int n) {
		Text.text = n + "/" + 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
