using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	/*void Start () {
		currentLevel = 1;
		fishCaughtTotal = 0;
		fishCaughtToday = 0;
		totalMoney = 0;
		fishInWater = 100;
		trashInWater = 0;
	}*/


}
