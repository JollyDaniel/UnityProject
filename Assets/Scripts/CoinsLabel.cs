using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLabel : MonoBehaviour
{

	public static CoinsLabel NCoinsCounter;
	public UILabel Text;

	private void Awake() {
		NCoinsCounter = this;
		UpdateCoins(0);
	}

	public void UpdateCoins(int nCoins)
	{
		string temp = "";
		if (nCoins < 10)
			temp = "00" + nCoins;
		else if (nCoins < 100)
			temp = "0" + nCoins;
		else if (nCoins < 10000)
			temp = "" + nCoins;
		Text.text = temp;
	}

}
