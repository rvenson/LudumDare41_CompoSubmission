using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridUI : MonoBehaviour {

	void Update(){
		RefreshGrid();
	}

	public void RefreshGrid(){
		int position = 1;
		foreach(Transform t in gameObject.transform){

			CarRaceTime grid = RaceManager.instance.GetGridList()[position - 1];

			GridCellUI cell = t.gameObject.GetComponent<GridCellUI>();
			cell.position.text = position.ToString();
			position += 1;
			cell.driverName.text = grid.car.GetDriver().GetDriverName();
			cell.teamName.text = grid.car.GetTeamName();
			cell.lapTime.text = grid.totalTime.ToString("F3");
		}
	}
}
