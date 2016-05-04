using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * StartGame
 * 
 * Starts LevelOne scene
 */ 
public class StartGame : MonoBehaviour {

	//Load main game scene
	public void LoadLevelOne(){
		SceneManager.LoadScene ("LevelOne");
	}
}

