using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

	public GameObject startScreen;
	public GameObject loadMenu;
	public GameObject mainMenu;
	public GameObject credits;
	public GameObject helpMenu;
	public GameObject nameMenu;

	public InputField driverNameInput;
	public GameObject alertDriverName;

	void Start(){
		StartScreen();
		AudioManager.instance.Play(0);
	}

	void Update(){
		if(startScreen.active){
			if(Input.anyKeyDown){
				MenuGame();
			}
		}
	}

	public void StartGame(){
		SceneManager.LoadScene("Game");
	}

	public void StartScreen(){
		startScreen.SetActive(true);
		loadMenu.SetActive(false);
		mainMenu.SetActive(false);
		credits.SetActive(false);
		helpMenu.SetActive(false);
		nameMenu.SetActive(false);
	}

	public void Credits(){
		startScreen.SetActive(false);
		loadMenu.SetActive(false);
		mainMenu.SetActive(false);
		credits.SetActive(true);
		helpMenu.SetActive(false);
		nameMenu.SetActive(false);
	}

	public void MenuGame(){
		startScreen.SetActive(false);
		loadMenu.SetActive(false);
		mainMenu.SetActive(true);
		credits.SetActive(false);
		helpMenu.SetActive(false);
		nameMenu.SetActive(false);
	}

	public void LoadScreen(){

		if(driverNameInput.text.Length > 2){
			//Load Driver Name
			GameManager.instance.driverName = driverNameInput.text;

			startScreen.SetActive(false);
			loadMenu.SetActive(true);
			mainMenu.SetActive(false);
			credits.SetActive(false);
			helpMenu.SetActive(false);
			nameMenu.SetActive(false);

			alertDriverName.SetActive(false);
		} else {
			alertDriverName.SetActive(true);
		}
	}

	public void HelpMenu(){
		startScreen.SetActive(false);
		loadMenu.SetActive(false);
		mainMenu.SetActive(false);
		credits.SetActive(false);
		helpMenu.SetActive(true);
		nameMenu.SetActive(false);
	}

	public void NameScreen(){
		startScreen.SetActive(false);
		loadMenu.SetActive(false);
		mainMenu.SetActive(false);
		credits.SetActive(false);
		helpMenu.SetActive(false);
		nameMenu.SetActive(true);
	}

	public void Exit(){
		Application.Quit();
	}
	
}
