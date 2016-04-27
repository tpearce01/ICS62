using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void LoadLevelOne(){
		SceneManager.LoadScene ("LevelOne");
	}
}
