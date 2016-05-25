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
	public Button nextButton;
	public Text instructionsText;
	public Text instructionsTitle;
	public Text titleText;
	public Text loadText;
	public GameObject InstructionPanel;
	public GameObject CreditsPanel;
	public Text creditsText;
	public Button creditsButton;


	private int fontSize;

	//Global Variables
	private GlobalVariablesScript globalVars;

	//Initialize global variables and adjust font sizes
	void Start() {
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();

		fontSize = (int)(globalVars.screenRatio * titleText.fontSize);
		titleText.fontSize = fontSize;
		instructionsTitle.fontSize = fontSize;
		loadText.GetComponentInChildren<Text> ().fontSize = fontSize;

		fontSize = (int)(globalVars.screenRatio * startButton.GetComponentInChildren<Text>().fontSize);
		startButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		instructionsButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		quitButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		nextButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		instructionsText.GetComponentInChildren<Text> ().fontSize = fontSize;
		creditsText.GetComponentInChildren<Text> ().fontSize = fontSize;
		creditsButton.GetComponentInChildren<Text> ().fontSize = fontSize;
	}

	//Set GUI objects active/inactive
	public void clickMe() {
		startButton.gameObject.SetActive (!startButton.IsActive ());
		instructionsButton.gameObject.SetActive (!instructionsButton.IsActive ());
		quitButton.gameObject.SetActive (!quitButton.IsActive ());
		instructionsText.gameObject.SetActive (!instructionsText.IsActive ());
		instructionsTitle.gameObject.SetActive (!instructionsTitle.IsActive ());
		titleText.gameObject.SetActive (!titleText.IsActive ());
		InstructionPanel.SetActive (!InstructionPanel.activeSelf);
		creditsButton.gameObject.SetActive (!creditsButton.IsActive ());
	}

	public void CreditsClicked(){
		//instructionsButton.gameObject.SetActive (!instructionsButton.IsActive ());
		startButton.gameObject.SetActive (!startButton.IsActive ());
		quitButton.gameObject.SetActive (!quitButton.IsActive ());
		creditsText.gameObject.SetActive (!creditsText.IsActive ());
		CreditsPanel.SetActive (!CreditsPanel.activeSelf);
	}
		

}
