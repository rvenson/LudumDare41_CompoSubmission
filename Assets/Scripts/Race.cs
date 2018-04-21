using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race {

	Circuit circuit;
	int currentLap = 0;
	Car mainPlayer;
	Grid grid;

	public Race(){
		circuit = new Circuit();
		mainPlayer = new Car();
		grid = new Grid();
	}

	public void StartRace(){
		PopulateGrid();
	}

	public Grid Grid(){
		return grid;
	}

	void PopulateGrid(){
		for(int i = 0; i < 20; i++){
			grid.carTime.Add(new CarRaceTime());
		}

		int driverNumber = 1;
		foreach(CarRaceTime c in grid.carTime){
			c.car.GetDriver().SetDriverName("Driver " + driverNumber);
			driverNumber += 1;
		}

		//Add grid start distance
		float gridGap = 0.05f;
		foreach(CarRaceTime c in grid.carTime){
			c.totalTime = gridGap;
			gridGap += 0.05f;
		}
	}

	public void DoALap(){
		//Calculate lap times
		CalculateLapTimes();

		//Verify for overtakings
		foreach(CarRaceTime c in grid.carTime){
			
		}

		//Verify for Disaster


		//Do a pitstop


		//Finish lap
		currentLap += 1;

		if(currentLap >= circuit.totalLaps){
			FinishRace();
		}
	}

	void CalculateLapTimes(){

		Stack<CarRaceTime> carsAheadTime = new Stack<CarRaceTime>();

		//Calculate lap times based in car performance and add to grid times
		foreach(CarRaceTime c in grid.carTime){
			//Calc laptime
			float lapTime = (c.car.CarPerformance() * circuit.baseTime) + Random.Range(0f, 0.1f);
			c.currentLapTime = lapTime;

			//Compare with all the cars ahead
			foreach(CarRaceTime other in carsAheadTime){

				if((c.totalTime + lapTime) < other.totalTime){
					//Debug.Log("t: " + (c.totalTime + lapTime) + "/" + other.totalTime);
					//Can overtaking
					if(Random.Range(0, 100) > 50){
						//Success overtaking
						//Debug.Log(c.car.GetDriver().GetDriverName() + 
						//" overtakes " + other.car.GetDriver().GetDriverName());
					} else {
						//fail to overtaking
						c.currentLapTime += (other.totalTime - (c.totalTime + c.currentLapTime));
						c.currentLapTime += Random.Range(0.05f, 0.2f);
						//Debug.Log(c.car.GetDriver().GetDriverName() + 
						//" fail to overtake " + other.car.GetDriver().GetDriverName());
					}
				} else {
					//Not overtaking
				}
			}

			//Registry lap time history and sum to the total time
			c.lapTime.Add(currentLap, c.currentLapTime);
			c.totalTime += c.currentLapTime;
			carsAheadTime.Push(c);

		}

		//align grid
		grid.carTime.Sort();
	}

	void FinishRace(){
		//End of Race
	}

	void DisasterDecision(){

	}

	void Pitstop(){

	}

	void OvertakingDecision(){

	}
}
