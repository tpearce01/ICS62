using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	public float timeStart;
	public Text textToUpdate;

	private float timeRemaining;
	private GlobalVariablesScript globalVars;

	// Use this for initialization
	void Start () {
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
		textToUpdate.text = "Time Remaining: " + (int)timeStart;
		timeRemaining = timeStart;
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

	void loadEndOfDay() {
		globalVars.currentLevel++;
		SceneManager.LoadScene ("EndOfDay");
	}
}
