using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * ReturnToMenuScript
 * 
 * Destroy persistent game object holding global variables and load the home scene (DefaultScene)
 */
public class ReturnToMenuScript : MonoBehaviour {

	private GlobalVariablesScript globalVars;

	public void loadDefaultScene() {
		Destroy (GameObject.FindGameObjectWithTag ("GlobalVariables"));

		SceneManager.LoadScene ("DefaultScene");
	}
}
