using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController : MonoBehaviour
{

    public ActionUI ui;
	List<string> phrase_warm = new List<string>();
    List<string> phrase_start = new List<string>();
    List<string> phrase_normal = new List<string>();
	List<string> phrase_final = new List<string>();

	List<string> phrase_motor = new List<string>();
	List<string> phrase_gearbox = new List<string>();
	List<string> phrase_suspension = new List<string>();
	List<string> phrase_breaks = new List<string>();
	List<string> phrase_tyres = new List<string>();
	List<string> phrase_fuel = new List<string>();


    void Awake()
    {
        phrase_warm.Add("Warm up msg");
		phrase_start.Add("The start was problematic and some cars run wide on the first corner. You left unharmed and managed to maintain your position, but the distance to the second place remains the same. Meanwhile, the two cars from behind remain very close. What do you want to do?");
		phrase_normal.Add("Normal Action");
		phrase_final.Add("Final Action");

		phrase_motor.Add("Motor Failure");
		phrase_gearbox.Add("Gearbox Failure");
		phrase_suspension.Add("Suspension Failure");
		phrase_breaks.Add("Breaks Failure");
		phrase_tyres.Add("Tyres Failure");
		phrase_fuel.Add("Fuel Failure");

    }

    public void WarmUpAction()
    {
        ui.msg.text = phrase_warm[0];
    }

    public void StartAction()
    {
        ui.msg.text = phrase_start[0];
    }

    public void NormalAction()
    {
        ui.msg.text = phrase_normal[0];
    }

	public void FinalAction(){
		ui.msg.text = phrase_final[0];
		ui.actions.gameObject.SetActive(false);
	}

	public void MotorFailure(){
		ui.msg.text = phrase_motor[0];
		ui.actions.gameObject.SetActive(false);
	}

	public void GearboxFailure(){
		ui.msg.text = phrase_gearbox[0];
		ui.actions.gameObject.SetActive(false);
	}

	public void SuspensionFailure(){
		ui.msg.text = phrase_suspension[0];
		ui.actions.gameObject.SetActive(false);
	}

	public void BreaksFailure(){
		ui.msg.text = phrase_breaks[0];
		ui.actions.gameObject.SetActive(false);
	}

	public void TyresFailure(){
		ui.msg.text = phrase_tyres[0];
		ui.actions.gameObject.SetActive(false);
	}

	public void FuelFailure(){
		ui.msg.text = phrase_fuel[0];
		ui.actions.gameObject.SetActive(false);
	}

    public void PushLap()
    {
        RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(4);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(4);
        RaceManager.instance.DoALap();
    }

    public void PaceLap()
    {
        RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(3);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(3);
        RaceManager.instance.DoALap();
    }

    public void EasyLap()
    {
        RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(2);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(2);
        RaceManager.instance.DoALap();
    }

	public void PitStopLap(){
		RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(3);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(3);
        RaceManager.instance.DoALap(true);
	}
}
