using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * ReturnToMenuScript
 * 
 * Destroy persistent game object holding global variables and load the home scene (DefaultScene)
 */
public class ReturnToMenuScript : MonoBehaviour {
	
	//Global variables
	private GlobalVariablesScript globalVars;

	//GUI vars
	public Text gameOverText;
	public Text generalText;
	public Button returnButton;
	private int fontSize;

	//Scale font sizes
	void Start() {
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();

		//Scale font size to resolution
		gameOverText.fontSize = (int)(globalVars.screenRatio * gameOverText.fontSize);
		generalText.fontSize = (int)(globalVars.screenRatio * generalText.fontSize);
		returnButton.GetComponentInChildren<Text>().fontSize = (int)(globalVars.screenRatio * generalText.fontSize);
	}

	//Return to start screen
	public void loadDefaultScene() {
		//recycle Global Variables
		Destroy (GameObject.FindGameObjectWithTag ("GlobalVariables"));

		//Return to start screen
		SceneManager.LoadScene ("DefaultScene");
	}
}
