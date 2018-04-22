using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionsController : MonoBehaviour
{

	public static ActionsController instance;

    public ActionUI ui;
	public ImageUI img;

	List<string> phrase_warm = new List<string>();
    List<string> phrase_start = new List<string>();
    List<string> phrase_normal = new List<string>();

	List<string> phrase_finalBest = new List<string>();
	List<string> phrase_finalGood = new List<string>();
	List<string> phrase_finalOK = new List<string>();
	List<string> phrase_finalBad = new List<string>();
	List<string> phrase_finalWorst = new List<string>();

	List<string> phrase_motor = new List<string>();
	List<string> phrase_gearbox = new List<string>();
	List<string> phrase_suspension = new List<string>();
	List<string> phrase_breaks = new List<string>();
	List<string> phrase_tyres = new List<string>();
	List<string> phrase_fuel = new List<string>();


    void Awake()
    {

		if(instance == null){
			instance = this;
		} else {
			Destroy(this.gameObject);
		}

        phrase_warm.Add("The start lights are on, it's time to show what I do best.");
		phrase_warm.Add("It looks like I'm going to have to work with so many good drivers starting close to me, but I need to gain some positions when the lights turn off.");
		phrase_warm.Add("I'm a little nervous. The car has not behaved very well on the opposite straight. Anyway, I'm sure I can keep my position until the mixed part of the circuit.");
		phrase_warm.Add("As soon as the lights go out I plan to attack some cars in front of me. There is no chance to lose.");

		phrase_start.Add("The start was problematic and some cars run wide on the first corner. You left unharmed and managed to maintain your position, but the distance to the second place remains the same. Meanwhile, the two cars from behind remain very close. What do you want to do?");
		
		phrase_normal.Add("One more lap completed. I need to keep the car at my fingertips.");
		phrase_normal.Add("Go! Go! Go!");
		phrase_normal.Add("One more lap, one more lap!");
		phrase_normal.Add("The car looked strange on the last lap. Are you sure there's nothing wrong?");
		phrase_normal.Add("That was a sexy lap");
		phrase_normal.Add("I’m driving like a grandma.");
		phrase_normal.Add("Woah! There’s a giant lizard on the track…. Yeah, I’m not joking! Out of Turn 3.");
		phrase_normal.Add("Oh, the annoying octopus is back! It’s been a while. It’s quite a small one. It’s a baby octopus.");
		phrase_normal.Add("One more lap completed. I need to keep the car at my fingertips.");
		phrase_normal.Add("One more lap completed. I need to keep the car at my fingertips.");
		phrase_normal.Add("One more lap completed. I need to keep the car at my fingertips.");

		phrase_finalBest.Add("Wow Wow Wow Wow! We are the champions, my friend!");
		phrase_finalBest.Add("We are the number one, baby! There's going to be a party at home today!");
		phrase_finalBest.Add("Uhuuuuuullllllll! I won! I won! I won! I WON!");
		phrase_finalBest.Add("Thank you so much guys. That’s a childhood dream come true. Thank you so much. We did it, we did it!");
		phrase_finalBest.Add("I will never forget this moment, this team, this job. Thank you, all of you guys…");
		phrase_finalGood.Add("It could have been better, but at least I have some champagne on the podium");
		phrase_finalGood.Add("Yeaaah! Great job, team! Next year I want victory, be warned!");
		phrase_finalGood.Add("The victory did not come, but thanks for the podium, guys!");
		phrase_finalOK.Add("Okay ... could have been worse.");
		phrase_finalOK.Add("Crossing the finish line was good enough");
		phrase_finalBad.Add("What a race to be forgotten ...");
		phrase_finalBad.Add("Terrible result. Next time give me a better car for me.");
		phrase_finalBad.Add("I did a **** job today");
		phrase_finalWorst.Add("Oh, f ** k! What I'll tell to my girlfriend?");
		phrase_finalWorst.Add("... [someone seems to be crying]");

		phrase_motor.Add("What? What was that noise? [A black smoke comes out of the car engine. It's the end of the race]");
		phrase_motor.Add("Uh? Come on .... [Car engine shut down]");
		phrase_motor.Add("F***ing car! F***ing car! F***in... [The radio was turned off by the GMA]");
		phrase_motor.Add("Does this smoke harms the environment?");
		phrase_motor.Add("I did what I could, I need to take more care of my car next time ... [The engine stopped]");

		phrase_gearbox.Add("[Gearbox Failure]");

		phrase_suspension.Add("[Suspension Failure]");
		
		phrase_breaks.Add("[Breaks Failure]");
		
		phrase_tyres.Add("[Tyres Failure]");
		
		phrase_fuel.Add("No one told me I needed to refuel? What kind of team is this?");
		phrase_fuel.Add("Right now that my car was floating! [Ran out of fuel]");
		phrase_fuel.Add("I thought refueling was banned, was not?");
		phrase_fuel.Add("Uh? Come on, just a few meters! [The car chokes near the last corner]");
		phrase_fuel.Add("Look, I swore we could run without fuel.");

    }

    public void WarmUpAction()
    {
        ui.msg.text = phrase_warm[Random.Range(0, phrase_warm.Count-1)];
		img.SetWarmUpImage();
    }

    public void StartAction()
    {
        ui.msg.text = phrase_start[Random.Range(0, phrase_start.Count-1)];
    }

    public void NormalAction()
    {
		ui.msg.text = phrase_normal[Random.Range(0, phrase_normal.Count-1)];
		img.SetNormalImage();
    }

	public void OvertakingAction(int diff){
		if(diff < -2){
			ui.msg.text = "I overtook several cars and won " + Mathf.Abs(diff) + " positions"; 
			img.SetOvertakeGainImage();
		} else if(diff < -1){
			ui.msg.text = "I overtook two cars!";
			img.SetOvertakeGainImage(); 
		} else if(diff == -1){
			ui.msg.text = "I overtook one car and gain one position";
			img.SetOvertakeGainImage(); 
		} else if(diff == 1){
			ui.msg.text = "I've been passed! Dammit!"; 
			img.SetOvertakeLossImage();
		} else if(diff > 1){
			ui.msg.text = "Two cars passed me! Overtaking could only have been illegal!"; 
			img.SetOvertakeLossImage();
		} else if(diff > 2){
			ui.msg.text = "F**k! I was overtaken by an entire gang!"; 
			img.SetOvertakeLossImage();
		} else {
			ui.msg.text = "What's happened?!"; 
		}
	}

	public void FinalAction(int p){

		if(p == 0){
			ui.msg.text = phrase_finalBest[Random.Range(0, phrase_finalBest.Count-1)];
			img.SetBestWinImage();
		} else if(p < 3){
			ui.msg.text = phrase_finalGood[Random.Range(0, phrase_finalGood.Count-1)];
			img.SetGoodWinImage();
		} else if(p < 7){
			ui.msg.text = phrase_finalOK[Random.Range(0, phrase_finalOK.Count-1)];
			img.SetOKWinImage();
		} else if(p < 12){
			ui.msg.text = phrase_finalBad[Random.Range(0, phrase_finalBad.Count-1)];
			img.SetBadWinImage();
		} else{
			ui.msg.text = phrase_finalWorst[Random.Range(0, phrase_finalWorst.Count-1)];
			img.SetWorstWinImage();
		}

		
		FinishGame();
	}

	public void BackToMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	public void MotorFailure(){
		ui.msg.text = phrase_motor[Random.Range(0, phrase_motor.Count-1)];
		img.SetDefeatImage();
		FinishGame();
	}

	public void GearboxFailure(){
		ui.msg.text = phrase_gearbox[Random.Range(0, phrase_gearbox.Count-1)];
		img.SetDefeatImage();
		FinishGame();
	}

	public void SuspensionFailure(){
		ui.msg.text = phrase_suspension[Random.Range(0, phrase_suspension.Count-1)];
		img.SetDefeatImage();
		FinishGame();
	}

	public void BreaksFailure(){
		ui.msg.text = phrase_breaks[Random.Range(0, phrase_breaks.Count-1)];
		img.SetDefeatImage();
		FinishGame();
	}

	public void TyresFailure(){
		ui.msg.text = phrase_tyres[Random.Range(0, phrase_tyres.Count-1)];
		img.SetDefeatImage();
		FinishGame();
	}

	public void FuelFailure(){
		ui.msg.text = phrase_fuel[Random.Range(0, phrase_fuel.Count-1)];
		img.SetDefeatImage();
		FinishGame();
	}

    public void PushLap()
    {
        RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(4);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(4);
        RaceManager.instance.DoALap();
    }

    public void PaceLap()
    {
        RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(3);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(3);
        RaceManager.instance.DoALap();
    }

    public void EasyLap()
    {
        RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(2);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(2);
        RaceManager.instance.DoALap();
    }

	public void PitStopLap(){
		RaceManager.instance.GetRace().GetMainPlayer().SetMotorMode(2);
        RaceManager.instance.GetRace().GetMainPlayer().SetTyreMode(2);
        RaceManager.instance.DoALap(true);
	}

	void FinishGame(){
		ui.actions.gameObject.SetActive(false);
		ui.backMenu.SetActive(true);
	}
}
