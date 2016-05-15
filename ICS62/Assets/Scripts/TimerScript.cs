using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * TimerScript
 * 
 * Runs the timer in LevelOne scene. When the timer is 0, the 
 * End of Day scene is loaded
 */ 
public class TimerScript : MonoBehaviour {

	//Timer variables
	public float timeStart;
	public Text textToUpdate;
	private Text fishText;
	private Text trashText;
	private float timeRemaining;

	//Global variables
	private GlobalVariablesScript globalVars;

	// Use this for initialization
	void Start () {
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
		textToUpdate.text = "Time Remaining: " + (int)timeStart;
		timeRemaining = timeStart;
		fishText = GameObject.FindGameObjectWithTag ("FishText").GetComponent<Text>();
		fishText.text = "Fish: " + globalVars.fishInWater;
		trashText = GameObject.FindGameObjectWithTag ("TrashText").GetComponent<Text>();
		trashText.text = "Trash: " + globalVars.trashInWater;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeRemaining > 0) {
			timeRemaining = timeRemaining - Time.deltaTime;
			textToUpdate.text = "Time Remaining: " + (int)timeRemaining;
		} else {
			loadEndOfDay ();
		}
	}

	//Load end of day scene and increment level
	void loadEndOfDay() {
		globalVars.currentLevel++;
		SceneManager.LoadScene ("EndOfDay");
	}
}
