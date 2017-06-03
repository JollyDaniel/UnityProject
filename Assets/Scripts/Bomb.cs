using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

	protected override void onRabitHit(Rabit rabit) {
		rabit.onBomb();
		CollectedHide();
	}
}
