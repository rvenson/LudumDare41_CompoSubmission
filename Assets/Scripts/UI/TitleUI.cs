using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour {

	public Text gameTitle;
	public Text circuitTitle;
	public Text laps;

	void Update(){
		Race race = RaceManager.instance.GetRace();
		laps.text = race.GetCurrentLap().ToString() + " / " + race.GetCircuit().totalLaps.ToString();
	}
}
