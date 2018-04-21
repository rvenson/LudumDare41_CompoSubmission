using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController : MonoBehaviour {

	public void DoALap(){
		RaceManager.instance.DoALap();
	}
}
