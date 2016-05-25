using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RodCastInWater : MonoBehaviour {

	public float catchWindow;	//How long the player has to catch a fish once a bite occurs
	public bool trashOnLine;	//Did the player catch trash?

	private PlayerController playerScript;		//to access player variables
	private GlobalVariablesScript globalVars;	//global variables

	public GameObject fishIcon;		//prefabs
	public GameObject playerBar;	//prefabs
	public GameObject progressBar;
	public GameObject triggerObject;
	public GameObject background;
	public GameObject reelAudio;
	public GameObject fishModel;

	private Text trashText;
	private AudioSource splashAudio;
	private int lastFishInWater;
	private GameObject fishIconCopy;
	private GameObject playerBarCopy;
	private GameObject progressBarCopy;
	private GameObject triggerObjectCopy;
	private GameObject backgroundCopy;
	private GameObject trashCaught;
	private GameObject reelAudioCopy;
	private GameObject fishModelCopy;

	private bool inWater;		//is the bobber in the water?
    // revert hasBite and gameStarted to private if necessary
	public bool hasBite;		//is a fish biting the line?
	public bool gameStarted;	//Has the minigame started?
	private float timeToLive;	//Time until fish bites
	private int moveX;			//variable for bobber movement on x coordinate
	private int moveZ;			//variable for bobber movement on z coordinate


	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
		trashOnLine = false;
		inWater = false;
		hasBite = false;
		gameStarted = false;
		trashText = GameObject.FindGameObjectWithTag ("TrashText").GetComponent<Text>();
		splashAudio = this.gameObject.GetComponent<AudioSource> ();
		lastFishInWater = globalVars.fishInWater;
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
				splashAudio.Play ();
			} else if (timeToLive < -catchWindow && hasBite) {
				//Fish is no longer active on the line
				hasBite = false;
			}
				
		}
	}

	void FixedUpdate() {
		//If a fish is biting the line, vibrate the bobber to alert the player
		if ((hasBite || gameStarted) && !trashOnLine) {
			moveX = Random.Range (-1, 2);
			moveZ = Random.Range (-1, 2);
			this.transform.position = new Vector3(this.transform.position.x + (moveX * 0.1f), this.transform.position.y, this.transform.position.z + (moveZ * 0.1f));
		}
		if (trashOnLine) {
			trashCaught.transform.position = this.transform.position;
		}
		if (globalVars.fishInWater < lastFishInWater) {
			fishModelCopy.transform.position = this.transform.position;
		}
	}

	//Check what the line collided with
	void OnTriggerEnter(Collider other) {
		//Destroy bobbers that land on the dock
		if (other.CompareTag ("Dock")) {
			//destroyBobber ();
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
		playerScript.hasCast = false;
	}

	//Called when line touches water
	void landedInWater () {
		//Set time to live to a pseudo-normalized range of 3 to 6 seconds
		timeToLive = Random.Range (1, 3) + Random.Range (1, 3) + Random.Range (1, 3);
		inWater = true;
	}

	//Called when player attempts to catch a fish
	void attemptCatch () {
		//Logic to try catching a fish
		if (hasBite && !gameStarted) {
			//catch success
			//Is it trash or a fish? catchThreshold = % of object that are fish
			float catchThreshold = (float) globalVars.fishInWater / (globalVars.fishInWater + globalVars.trashInWater);
			float roll = Random.Range (0.0f, 1.0f);
			Debug.Log ("CatchThreshold: " + catchThreshold);
			Debug.Log ("Roll: " + roll);
			if (catchThreshold >= roll) {
				//fish
				Debug.Log("Fish on line");
				gameStarted = true;
				reelAudioCopy = (GameObject)Instantiate (reelAudio, this.transform.position, this.transform.rotation);
				startMinigame ();
			} else {
				//trash
				Debug.Log("Trash on line");
				globalVars.trashInWater--;
				trashText.text = "Trash: " + globalVars.trashInWater;
				trashOnLine = true;
				trashCaught = GameObject.FindGameObjectWithTag ("Trash");
				trashCaught.GetComponent<Rigidbody> ().useGravity = true;
				destroyBobber ();
			}


		} else {
			//Catch fail
			if (!gameStarted) {
				//Destroy (this.gameObject);
				destroyBobber();
			}
		}

	}

	public void destroyBobber(){
		if (globalVars.fishInWater < lastFishInWater) {
			fishModelCopy = (GameObject)Instantiate (fishModel, this.transform.position, this.transform.rotation);
		}
		if (GameObject.FindGameObjectWithTag ("ReelAudio") != null) {
			Destroy (GameObject.FindGameObjectWithTag ("ReelAudio"));
		}
		if (gameStarted) {
			Destroy (fishIconCopy);
			Destroy (progressBarCopy);
			Destroy (backgroundCopy);
		}
		//Destroy (this.gameObject);
		//transform.LookAt(playerScript.gameObject);
		float distance = Vector3.Distance(this.transform.position, playerScript.gameObject.transform.position);
		Debug.Log ("Distance: " + distance);
		if (distance < 12) {
			distance = 14;
		}
		inWater = false;
		this.GetComponent<Rigidbody> ().useGravity = true;
		transform.LookAt (playerScript.gameObject.transform.position);
		this.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 400);
		this.gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * 33 * distance);
	}
		
	void startMinigame(){
		//Instantiate and set parent here
		GameObject canvasObj = GameObject.FindGameObjectWithTag ("Canvas");
		backgroundCopy = (GameObject)Instantiate (background, canvasObj.transform.position, canvasObj.transform.rotation);
		backgroundCopy.transform.parent = canvasObj.transform;
		playerBarCopy = (GameObject) Instantiate (playerBar, canvasObj.transform.position, canvasObj.transform.rotation);
		playerBarCopy.transform.parent = canvasObj.transform;
		fishIconCopy = (GameObject) Instantiate ( fishIcon, canvasObj.transform.position, canvasObj.transform.rotation);
		fishIconCopy.transform.Rotate (0, 0, 90);
		fishIconCopy.transform.parent = canvasObj.transform;
		progressBarCopy = (GameObject)Instantiate (progressBar, canvasObj.transform.position, canvasObj.transform.rotation);
		progressBarCopy.transform.parent = canvasObj.transform;
		progressBarCopy.transform.Translate(new Vector3(60,0,0));
		triggerObjectCopy = (GameObject)Instantiate (triggerObject, canvasObj.transform.position, canvasObj.transform.rotation);
		triggerObjectCopy.transform.parent = canvasObj.transform;

	}

}
