using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour {

	public static RaceManager instance;
	Race race = new Race();

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	void Start(){
		race.StartRace();
		race.DoALap();
	}

	public void DoALap(){
		race.DoALap();
	}

	public List<CarRaceTime> GetGridList(){
		return race.Grid().carTime;
	}

}
