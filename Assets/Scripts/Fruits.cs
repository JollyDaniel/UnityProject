using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Collectable {

	protected override void onRabitHit(Rabit rabit) {
		LevelControler.current.addFruits(1);
		CollectedHide();
	}
}