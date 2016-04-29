using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * InstructionsButton
 * 
 * Activates/deactivates the specified objects
 */ 
public class InstructionsButton : MonoBehaviour {
	

	public Button startButton;
	public Button instructionsButton;
	public Button quitButton;
	public Button returnButton;
	public Text instructionsText;
	public Text instructionsTitle;
	public Text titleText;

	public int nativeWidth;
	public int nativeHeight;

	private float screenRatio;
	private int fontSize;

	void Start() {
		screenRatio = Screen.width / nativeWidth;
		fontSize = (int)(screenRatio * titleText.fontSize);
		titleText.fontSize = fontSize;
		instructionsTitle.fontSize = fontSize;

		fontSize = (int)(screenRatio * startButton.GetComponentInChildren<Text>().fontSize);
		startButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		instructionsButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		quitButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		returnButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		instructionsText.GetComponentInChildren<Text> ().fontSize = fontSize;
	}

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
