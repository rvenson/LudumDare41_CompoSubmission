using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public AudioClip[] songs;
	public AudioSource musicPlayer;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(this.gameObject);
		}
	}

	public void Play(int index){
		musicPlayer.clip = songs[index];
		musicPlayer.loop = true;
		musicPlayer.Play();
	}

	public void PlayUnloop(int index){
		musicPlayer.clip = songs[index];
		musicPlayer.loop = false;
		musicPlayer.Play();
	}

	public void Stop(){
		musicPlayer.Stop();
	}


	
}
