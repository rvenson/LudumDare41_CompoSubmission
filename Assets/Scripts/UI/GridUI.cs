using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GridUI : MonoBehaviour {

	float leaderTime;

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
			//Colour player
			if(grid.car.GetDriver().GetDriverName() == GameManager.instance.driverName){
				cell.driverName.color = Color.green;
			} else {
				cell.driverName.color = Color.white;
			}
			cell.teamName.text = grid.car.GetTeamName();

			if(position == 2){
				cell.lapTime.text = FormatSeconds(grid.totalTime);
				leaderTime = grid.totalTime;
			} else {
				cell.lapTime.text = (grid.totalTime - leaderTime).ToString("'+' 0.000");
			}
		}
	}

	    string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;
        return String.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}
