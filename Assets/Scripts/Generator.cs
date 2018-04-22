using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator {

	List<Driver> drivers = new List<Driver>();
	List<Car> cars = new List<Car>();

	public static Grid GenerateGrid(){

		Grid grid = new Grid();
		grid.carTime.Add(new CarRaceTime(new Car("MER", new Driver("Louis Ham", 10, 10, 10), 29)));
		grid.carTime.Add(new CarRaceTime(new Car("FER", new Driver("Sebast Vent", 10, 10, 10), 30)));
		grid.carTime.Add(new CarRaceTime(new Car("MER", new Driver("Valter Toppas", 10, 9, 9), 31)));
		grid.carTime.Add(new CarRaceTime(new Car("RBR", new Driver("Daniel Reinaldo", 9, 10, 10), 30)));
		grid.carTime.Add(new CarRaceTime(new Car("FER", new Driver("Kin Konnen", 9, 10, 9), 28)));
		grid.carTime.Add(new CarRaceTime(new Car("MCL", new Driver("Francis Olonso", 10, 10, 10), 27)));
		grid.carTime.Add(new CarRaceTime(new Car("REN", new Driver("Nick Robiff", 9, 9, 9), 34)));
		grid.carTime.Add(new CarRaceTime(new Car("RBR", new Driver("Max Ernest", 8, 10, 10), 30)));
		grid.carTime.Add(new CarRaceTime(new Car("TRT", new Driver("Pietro Gally", 9, 9, 8), 28)));
		grid.carTime.Add(new CarRaceTime(new Car("HAS", new Driver("Kenin Magno", 8, 8, 8), 29)));
		grid.carTime.Add(new CarRaceTime(new Car("MCL", new Driver("Steffan Alborne", 9, 8, 8), 32)));
		grid.carTime.Add(new CarRaceTime(new Car("REN", new Driver("Camilo San Jr.", 9, 9, 8), 33)));
		grid.carTime.Add(new CarRaceTime(new Car("SAU", new Driver("Mark Nokkia", 8, 8, 8), 25)));
		grid.carTime.Add(new CarRaceTime(new Car("FOR", new Driver("Estevan Arcon", 8, 8, 9), 23)));
		grid.carTime.Add(new CarRaceTime(new Car("FOR", new Driver("Sergey Petrez", 9, 8, 9), 21)));
		grid.carTime.Add(new CarRaceTime(new Car("SAU", new Driver("Chev Lermec", 7, 8, 9), 29)));
		grid.carTime.Add(new CarRaceTime(new Car("HAS", new Driver("Romano Gracejan", 9, 8, 7), 35)));
		grid.carTime.Add(new CarRaceTime(new Car("WIL", new Driver("Lone Stroll", 10, 9, 7), 30)));
		grid.carTime.Add(new CarRaceTime(new Car("TTR", new Driver("Bred Halay", 8, 7, 7), 25)));
		
		return grid;
		}
}
