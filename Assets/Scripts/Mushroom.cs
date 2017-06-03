using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {

	protected override void onRabitHit(Rabit rabit) {
		rabit.startGetingBiger();
		CollectedHide();
	}
}
