using UnityEngine;
using System.Collections;

public class RodCastInWater : MonoBehaviour {

	public float catchWindow;	//How long the player has to catch a fish once a bite occurs

	private PlayerController playerScript;		//to access player variables
	private GlobalVariablesScript globalVars;	//global variables

	public GameObject fishIcon;		//prefabs
	public GameObject playerBar;	//prefabs

	private GameObject fishIconCopy;
	private GameObject playerBarCopy;

	private bool inWater;		//is the bobber in the water?
	private bool hasBite;		//is a fish biting the line?
	private bool gameStarted;	//Has the minigame started?
	private float timeToLive;	//Time until fish bites
	private int moveX;			//variable for bobber movement on x coordinate
	private int moveZ;			//variable for bobber movement on z coordinate


	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
		inWater = false;
		hasBite = false;
		gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inWater) {
			//decrement line timer
			timeToLive -= Time.deltaTime;

			//If player clicks mouse, try to catch it
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				attemptCatch ();
			}

			if (timeToLive < 0 && !hasBite && timeToLive > -catchWindow) {
				//Fish is active on the line. Player has 1.5 seconds to respond successfully
				hasBite = true;
			} else if (timeToLive < -catchWindow && hasBite) {
				//Fish is no longer active on the line
				hasBite = false;
			}
				
		}
	}

	void FixedUpdate() {
		//If a fish is biting the line, vibrate the bobber to alert the player
		if (hasBite || gameStarted) {
			moveX = Random.Range (-1, 2);
			moveZ = Random.Range (-1, 2);
			this.transform.position = new Vector3(this.transform.position.x + (moveX * 0.1f), this.transform.position.y, this.transform.position.z + (moveZ * 0.1f));
		}
	}

	//Check what the line collided with
	void OnTriggerEnter(Collider other) {
		//Destroy bobbers that land on the dock
		if (other.CompareTag ("Dock")) {
			Destroy (this.gameObject);
		}
		//Halt bobber once it lands in the water
		if (other.CompareTag ("Water")) {
			this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			this.GetComponent<Rigidbody> ().useGravity = false;
			landedInWater ();
		}
	}

	//Reset hasCast to false
	void OnDestroy() {
		Debug.Log ("Object destroyed");
		playerScript.hasCast = false;
	}

	//Called when line touches water
	void landedInWater () {
		//Set time to live to a pseudo-normalized range of 3 to 6 seconds
		timeToLive = Random.Range (1, 3) + Random.Range (1, 3) + Random.Range (1, 3);
		//Debug.Log("timeToLive set: " + timeToLive + " seconds");
		inWater = true;
	}

	//Called when player attempts to catch a fish
	void attemptCatch () {
		//Logic to try catching a fish
		if (hasBite && !gameStarted) {
			//catch success
			gameStarted = true;
			startMinigame ();

		} else {
			//Catch fail
			if (!gameStarted) {
				Destroy (this.gameObject);
			}
		}

	}

	public void destroyBobber(){
		Destroy (this.gameObject);
	}
		
	void startMinigame(){
		//Instantiate and set parent here
		GameObject canvasObj = GameObject.FindGameObjectWithTag ("Canvas");
		fishIconCopy = (GameObject) Instantiate ( fishIcon, canvasObj.transform.position, canvasObj.transform.rotation);
		fishIconCopy.transform.Rotate (0, 0, 90);
		fishIconCopy.transform.parent = canvasObj.transform;
		playerBarCopy = (GameObject) Instantiate (playerBar, canvasObj.transform.position, canvasObj.transform.rotation);
		playerBarCopy.transform.parent = canvasObj.transform;
	}

}
