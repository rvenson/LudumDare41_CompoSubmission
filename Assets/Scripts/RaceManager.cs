using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour {

	public static RaceManager instance;
	Race race = new Race();
	public ActionsController actions;
	int lastPosition = 2;

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	void Start(){
		race.StartRace();
		actions.WarmUpAction();
	}

	public void DoALap(bool pitstop = false){
		int code = race.DoALap(pitstop);
		int difference = race.GetMainPlayerPosition() - lastPosition;
		
		if(difference != 0){
			lastPosition = race.GetMainPlayerPosition();
			code = 2;
		}

		//Update Actions
		switch (code)
		{

			case 2: {
				actions.OvertakingAction(difference);
				break;
			}

			case 1: {
				actions.NormalAction();
				break;
			}

			case -1: {
				Debug.Log("Final Position: " + race.GetMainPlayerPosition());
				actions.FinalAction(race.GetMainPlayerPosition());
				break;
			}

			case -100: {
				actions.MotorFailure();
				break;
			}

			case -200: {
				actions.GearboxFailure();
				break;
			}

			case -300: {
				actions.SuspensionFailure();
				break;
			}

			case -400: {
				actions.BreaksFailure();
				break;
			}

			case -500: {
				actions.TyresFailure();
				break;
			}

			case -600: {
				actions.FuelFailure();
				break;
			}
			
			default: {
				break;
			}
		}
	}

	public Race GetRace(){
		return race;
	}

	public List<CarRaceTime> GetGridList(){
		return race.Grid().carTime;
	}

}
