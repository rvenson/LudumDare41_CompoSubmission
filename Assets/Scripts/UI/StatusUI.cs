using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour {

	public Text motor;
	public Text gearbox;
	public Text suspension;
	public Text brakes;
	public Text tyres;
	public Text fuel;

	void Update(){
		Refresh();
	}

	void Refresh(){
		Car car = RaceManager.instance.GetRace().mainPlayer.car;
		motor.text = car.GetMotor().GetStatus().ToString("#'%'");
		gearbox.text = car.GetGearbox().GetStatus().ToString("#'%'");
		suspension.text = car.GetSuspension().GetStatus().ToString("#'%'");
		brakes.text = car.GetBrakes().GetStatus().ToString("#'%'");
		tyres.text = car.GetTyres().GetStatus().ToString("#'%'");
		fuel.text = car.GetFuel().ToString("F1");
	}
}
