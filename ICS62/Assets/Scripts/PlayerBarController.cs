using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBarController : MonoBehaviour {
	public int forceToAdd;
	private Slider progressBar;
	public bool isOverlapping;

	private Text fishText;
	private GameObject thisObject;
	private Rigidbody2D thisRB;
	private bool minigameStart;
	private RodCastInWater bobberScript;
	private GlobalVariablesScript globalVars;

	// Use this for initialization
	void Start () {
		minigameStart = false;
		isOverlapping = false;
		thisObject = this.gameObject;
		thisRB = thisObject.GetComponent<Rigidbody2D> ();
		bobberScript = GameObject.FindGameObjectWithTag ("Bobber").GetComponent<RodCastInWater> ();
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
		progressBar = GameObject.FindGameObjectWithTag ("ProgressBar").GetComponent<Slider> ();
		progressBar.value = .5f;
		fishText = GameObject.FindGameObjectWithTag ("FishText").GetComponent<Text>();
		startGame ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Mouse0)){
			thisRB.AddForce(transform.up * forceToAdd);
		}
		if (isOverlapping) {
			progressBar.value += .26f * Time.deltaTime;
		} else {
			progressBar.value -= .22f * Time.deltaTime;
		}

		if (progressBar.value >= 1.0f) {
			//Fish captured
			globalVars.fishCaughtToday++;
			globalVars.fishInWater--;
			fishText.text = "Fish: " + globalVars.fishInWater;
			endGame();
		} else if (progressBar.value <= 0f) {
			//Fish got away
			bobberScript.trashOnLine = true;	//Prevent bobber from wobbling
			endGame();
		}

	}

	public void startGame(){
		minigameStart = true;
	}

	public void endGame() {
		minigameStart = false;
		bobberScript.destroyBobber ();
		Destroy (GameObject.FindGameObjectWithTag ("Trigger"));
		Destroy (this.gameObject);
		Destroy (this);
	}
		

}
