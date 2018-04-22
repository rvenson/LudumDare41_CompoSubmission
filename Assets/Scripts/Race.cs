using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour {

	Circuit circuit;
	int currentLap = 0;
	public CarRaceTime mainPlayer;
	public Grid grid;

	public Race(){
		circuit = new Circuit();
		grid = new Grid();
	}

	public Circuit GetCircuit(){
		return circuit;
	}

	public int GetCurrentLap(){
		return currentLap;
	}

	public void StartRace(){
		PopulateGrid();
	}

	public Grid Grid(){
		return grid;
	}

	void PopulateGrid(){
		/*
		for(int i = 0; i < 19; i++){
			grid.carTime.Add(new CarRaceTime());
		}

		int driverNumber = 1;
		foreach(CarRaceTime c in grid.carTime){
			c.car.GetDriver().SetDriverName("Driver " + driverNumber);
			driverNumber += 1;
		}
		 */

		grid = Generator.GenerateGrid();

		//AddMainPlayer
		mainPlayer = new CarRaceTime(new Car("SRT", new Driver("Ramon Venson", 1, 1, 1),
		new CarPart(), new CarPart(), new CarPart(), new CarPart(), new CarPart(), 35
		));
		grid.carTime.Insert(2, mainPlayer);

		//Add grid start distance
		float gridGap = 0.05f;
		foreach(CarRaceTime c in grid.carTime){
			c.totalTime = gridGap;
			gridGap += 0.05f;
		}
	}

	public int DoALap(bool pitstop = false){
			//Calculate lap times
			CalculateLapTimes(pitstop);		

			//Verify for Disaster
			if(mainPlayer.car.GetMotor().GetStatus() <= 0){
				return -100;
			} else if(mainPlayer.car.GetGearbox().GetStatus() <= 0){
				return -200;
			} else if(mainPlayer.car.GetSuspension().GetStatus() <= 0){
				return -300;
			} else if(mainPlayer.car.GetBrakes().GetStatus() <= 0){
				return -400;
			} else if(mainPlayer.car.GetTyres().GetStatus() <= 0){
				return -500;
			} else if(mainPlayer.car.GetFuel() <= 0){
				return -600;
			}

			//grid.carTime.Sort();

			//Finish lap
			currentLap += 1;

			if(currentLap < circuit.totalLaps){
				return 1;
			} else {
				FinishRace();
				return -1;
			}
	}

	void CalculateLapTimes(bool pitstop = false){

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
						Debug.Log(c.car.GetDriver().GetDriverName() + 
						" overtakes " + other.car.GetDriver().GetDriverName());
					} else {
						//fail to overtaking
						c.currentLapTime += (other.totalTime - (c.totalTime + c.currentLapTime));
						c.currentLapTime += Random.Range(0.05f, 0.2f);
						Debug.Log(c.car.GetDriver().GetDriverName() + 
						" fail to overtake " + other.car.GetDriver().GetDriverName());
					}
				} else {
					//Not overtaking
				}
			}

			//Registry lap time history and sum to the total time
			c.lapTime.Add(currentLap, c.currentLapTime);
			c.totalTime += c.currentLapTime;
			carsAheadTime.Push(c);

			c.car.ApplyPartsWear();

		}

		//Pitstop
		foreach(CarRaceTime c in grid.carTime){
			//Pitstop check if bot
			if(c != GetMainPlayerGrid() && c.car.GetFuel() <= 1){
				Pitstop(c);
			}
		}

		if (pitstop){
			Pitstop(GetMainPlayerGrid());
		}

		//align grid
		grid.carTime.Sort();
	}

	public Car GetMainPlayer(){
		return grid.carTime[grid.carTime.IndexOf(mainPlayer)].car;
	}

	public CarRaceTime GetMainPlayerGrid(){
		return grid.carTime[grid.carTime.IndexOf(mainPlayer)];
	}

	void FinishRace(){
		//End of Race
	}


	void Pitstop(CarRaceTime c){
		grid.carTime[grid.carTime.IndexOf(c)].totalTime += Random.Range(17f, 17.4f);
		grid.carTime[grid.carTime.IndexOf(c)].car.Refuel(30);
		Debug.Log(c.car.GetDriver().GetDriverName() + " stopped in boxes");
	}
}
