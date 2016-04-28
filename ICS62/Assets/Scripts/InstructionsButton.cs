using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionsButton : MonoBehaviour {

	public Button startButton;
	public Button instructionsButton;
	public Button quitButton;
	public Button returnButton;

	public void clickMe() {
		startButton.gameObject.SetActive (!startButton.IsActive ());
		instructionsButton.gameObject.SetActive (!instructionsButton.IsActive ());
		quitButton.gameObject.SetActive (!quitButton.IsActive ());
		returnButton.gameObject.SetActive (!returnButton.IsActive ());
	}
		

}
