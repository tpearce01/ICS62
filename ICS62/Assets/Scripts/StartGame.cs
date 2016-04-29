using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * StartGame
 * 
 * Starts LevelOne scene
 */ 
public class StartGame : MonoBehaviour {


	public void LoadLevelOne(){
		SceneManager.LoadScene ("LevelOne");
	}
}
