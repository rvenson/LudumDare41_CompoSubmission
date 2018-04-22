using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car {

	string teamName;
	Driver driver;
	CarPart motor;
	CarPart gearbox;
	CarPart suspension;
	CarPart brakes;
	CarPart tyres;
	float fuel;

	int motorMode = 3;
	int tyresMode = 3;

	public Car(){
		teamName = "DefaultTeam";
		driver = new Driver();
		motor = new CarPart();
		gearbox = new CarPart();
		suspension = new CarPart();
		brakes = new CarPart();
		tyres = new CarPart();
		fuel = 30;
	}

	public Car(string teamName, Driver driver, int fuel){
		this.teamName = teamName;
		this.driver = driver;
		this.motor = new CarPart();
		this.gearbox = new CarPart();
		this.suspension = new CarPart();
		this.brakes = new CarPart();
		this.tyres = new CarPart();
		this.fuel = fuel;

	}

	public Car(string teamName, Driver driver, CarPart motor, CarPart gearbox, CarPart suspension, 
	CarPart brakes, CarPart tyres, int fuel){
		this.teamName = teamName;
		this.driver = driver;
		this.motor = motor;
		this.gearbox = gearbox;
		this.suspension = suspension;
		this.brakes = brakes;
		this.tyres = tyres;
		this.fuel = fuel;

	}

	public float CarPerformance(){
		//Calculate car performance for lap proposes
		return 1f - ((tyresMode * motorMode)/8000f);
	}

	public void ApplyPartsWear(){
		motor.ApplyWear(motorMode/1.5f);
		gearbox.ApplyWear(motorMode/1.6f);
		suspension.ApplyWear(1);
		brakes.ApplyWear(tyresMode/1.6f);
		tyres.ApplyWear(tyresMode/1.2f);
		fuel -= 0.7f + (motorMode/10f);
	}

	public Driver GetDriver(){
		return driver;
	}

	public string GetTeamName(){
		return teamName;
	}

	public CarPart GetMotor(){
		return motor;
	}

	public CarPart GetGearbox(){
		return gearbox;
	}
	public CarPart GetSuspension(){
		return suspension;
	}
	public CarPart GetBrakes(){
		return brakes;
	}
	public CarPart GetTyres(){
		return tyres;
	}
	
	public float GetFuel(){
		return fuel;
	}

	public void SetMotorMode(int i){
		motorMode = i;
	}
	
	public void SetTyreMode(int i){
		tyresMode = i;
	}

	public void Refuel(int fuel){
		this.fuel = Mathf.Clamp(this.fuel + fuel, 0, 35);
		ChangeTyres();
	}

	public void ChangeTyres(){
		this.tyres = new CarPart();
	}
}
