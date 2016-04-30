using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * InstructionsButton
 * 
 * Activates/deactivates the specified objects
 */ 
public class InstructionsButton : MonoBehaviour {
	
	//GUI variables
	public Button startButton;
	public Button instructionsButton;
	public Button quitButton;
	public Button returnButton;
	public Text instructionsText;
	public Text instructionsTitle;
	public Text titleText;
	private int fontSize;

	//Global Variables
	private GlobalVariablesScript globalVars;

	//Initialize global variables and adjust font sizes
	void Start() {
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();

		fontSize = (int)(globalVars.screenRatio * titleText.fontSize);
		titleText.fontSize = fontSize;
		instructionsTitle.fontSize = fontSize;

		fontSize = (int)(globalVars.screenRatio * startButton.GetComponentInChildren<Text>().fontSize);
		startButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		instructionsButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		quitButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		returnButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		instructionsText.GetComponentInChildren<Text> ().fontSize = fontSize;
	}

	//Set GUI objects active/inactive
	public void clickMe() {
		startButton.gameObject.SetActive (!startButton.IsActive ());
		instructionsButton.gameObject.SetActive (!instructionsButton.IsActive ());
		quitButton.gameObject.SetActive (!quitButton.IsActive ());
		returnButton.gameObject.SetActive (!returnButton.IsActive ());
		instructionsText.gameObject.SetActive (!instructionsText.IsActive ());
		instructionsTitle.gameObject.SetActive (!instructionsTitle.IsActive ());
		titleText.gameObject.SetActive (!titleText.IsActive ());
	}
		

}
