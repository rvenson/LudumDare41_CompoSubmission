using System.Collections;
using System.Collections.Generic;
using System;

public class CarRaceTime : IComparable<CarRaceTime> {

	public Car car;
	public float totalTime;
	public float currentLapTime;
	public Dictionary<int, float> lapTime;

	public CarRaceTime(){
		car = new Car();
		totalTime = 0;
		lapTime = new Dictionary<int, float>();
	}

	public int CompareTo(CarRaceTime other)
    {
        if(other == null)
        {
            return 1;
        }
        
        //Return the difference in power.
		if(totalTime >= other.totalTime){
			return 1;
		} else {
			return -1;
		}
    }

}
