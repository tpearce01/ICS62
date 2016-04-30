using UnityEngine;
using System.Collections;

/*
 * GlobalVariablesScript
 * 
 * Contains a list of variables that need to persist between scenes.
 * This object is not destroyed between scenes, unless the player 
 * reaches a Game Over state.
 */ 
public class GlobalVariablesScript : MonoBehaviour {

	//Gameplay data
	public int currentLevel;
	public int fishCaughtTotal;
	public int fishCaughtToday;
	public int totalMoney;
	public int fishInWater;
	public int trashInWater;

	//GUI variables
	public int nativeWidth;
	public int nativeHeight;
	public float screenRatio;

	//Make global variables persistent
	void Awake () {
		DontDestroyOnLoad (this);

		screenRatio = Screen.width / nativeWidth;	//Determine screen ratio to native width
	}


}
