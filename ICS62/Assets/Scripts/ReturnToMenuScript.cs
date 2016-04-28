using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToMenuScript : MonoBehaviour {

	private GlobalVariablesScript globalVars;

	public void loadDefaultScene() {
		//globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
		Destroy (GameObject.FindGameObjectWithTag ("GlobalVariables"));

		SceneManager.LoadScene ("DefaultScene");
	}
}
