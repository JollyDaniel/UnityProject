using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Collectable {

	public int id;

	protected override void onRabitHit(Rabit rabit) {
		LevelControler.current.addCrystals(1);
		CrystalsUI.crystalsUI.setCrystalCollected(id);
		CollectedHide();
	}
}
