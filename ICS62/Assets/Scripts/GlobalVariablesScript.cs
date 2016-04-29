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

	public int currentLevel;
	public int fishCaughtTotal;
	public int fishCaughtToday;
	public int totalMoney;
	public int fishInWater;
	public int trashInWater;

	void Awake () {
		DontDestroyOnLoad (this);
	}


}
