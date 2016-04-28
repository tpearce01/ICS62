using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionsButton : MonoBehaviour {

	public Button startButton;
	public Button instructionsButton;
	public Button quitButton;
	public Button returnButton;
	public Text instructionsText;
	public Text instructionsTitle;
	public Text titleText;

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
