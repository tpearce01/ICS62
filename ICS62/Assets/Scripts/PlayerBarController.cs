using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBarController : MonoBehaviour {
	public int forceToAdd;
	private Slider progressBar;
	public bool isOverlapping;

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
		startGame ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Mouse0)){
			//Debug.Log ("playerBar registered mouse click");
			thisRB.AddForce(transform.up * forceToAdd);
		}
		if (isOverlapping) {
			progressBar.value += .3f * Time.deltaTime;
		} else {
			progressBar.value -= .3f * Time.deltaTime;
		}

		if (progressBar.value >= 1.0f) {
			//Fish captured
			Debug.Log("progressBar = 1");
			globalVars.fishCaughtToday++;
			endGame();
		} else if (progressBar.value <= 0f) {
			//Fish got away
			Debug.Log("progress bar = 0");
			endGame();
		}

	}

	public void startGame(){
		minigameStart = true;
	}

	public void endGame() {
		Debug.Log ("PlayerBarController endGame()");
		minigameStart = false;
		bobberScript.destroyBobber ();
		Destroy (GameObject.FindGameObjectWithTag ("Trigger"));
		Destroy (this.gameObject);
		Destroy (this);
	}
		

}
