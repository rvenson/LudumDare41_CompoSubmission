using System.Collections;
using System.Collections.Generic;

public class Car {

	string teamName;
	Driver driver;
	CarPart motor;
	CarPart gearbox;
	CarPart suspension;
	CarPart brakes;
	CarPart tyres;
	int gas;

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
		gas = 40;
	}

	public int CarPerformance(){
		//Calculate car performance for lap proposes
		return 1;
	}

	public void ApplyPartsWear(){
		motor.ApplyWear(motorMode);
		gearbox.ApplyWear(motorMode);
		suspension.ApplyWear(1);
		brakes.ApplyWear(tyresMode);
		tyres.ApplyWear(tyresMode);
	}

	public Driver GetDriver(){
		return driver;
	}

}
