using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Collectable {

	protected override void onRabitHit(Rabit rabit) {
		LevelControler.current.addCrystals(1);
		CollectedHide();
	}
}
