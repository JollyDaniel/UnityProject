using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

	protected override void onRabitHit(Rabit rabit) {
		LevelControler.current.addCoins(1);
		CollectedHide();
	}
}
