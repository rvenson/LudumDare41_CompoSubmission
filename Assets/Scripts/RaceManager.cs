using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour {

	Race race = new Race();

	void Start(){
		race.StartRace();
		race.DoALap();

		foreach(CarRaceTime c in race.Grid().carTime){
			Debug.Log(c.car.GetDriver().GetDriverName() + " : " + c.totalTime);
		}
	}

}
