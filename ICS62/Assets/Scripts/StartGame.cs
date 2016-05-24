using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * StartGame
 * 
 * Starts LevelOne scene
 */ 
public class StartGame : MonoBehaviour {

	public Text loadText;
	public Image loadImage;

	//Load main game scene
	public void LoadLevelOne(){
		loadText.gameObject.SetActive (true);
		loadImage.gameObject.SetActive (true);
		SceneManager.LoadScene ("LevelOne");
	}
}

