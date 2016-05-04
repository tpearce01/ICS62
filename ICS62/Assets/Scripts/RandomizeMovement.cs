using UnityEngine;
using System.Collections;

public class RandomizeMovement : MonoBehaviour {
	private float randomTimer;
	public float baseForce;
	private float randomForce;
	private bool minigameStart;
	//private GameObject fishIcon;

	void Start() {
		minigameStart = false;
		//fishIcon = GameObject.FindGameObjectWithTag ("FishIcon");
		Physics2D.IgnoreCollision (this.gameObject.GetComponent<Collider2D> (), GameObject.FindGameObjectWithTag("PlayerBar").GetComponent<Collider2D> ());

		startGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (minigameStart) {
			randomTimer -= Time.deltaTime;

			if (randomTimer < 0) {
				randomTimer = Random.Range (0f, 1f);	//random float between 0 and 2
				randomForce = Random.Range (0.5f, 2f);	//random float between 0 and 1
				//Debug.Log ("randomForce: " + randomForce);
				//Debug.Log ("randomTimer: " + randomTimer);
				this.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right * randomForce * baseForce);
			}
		}
	}

	public void startGame(){
		minigameStart = true;
		//fishObject.SetActive (!fishObject.activeSelf);
	}

	public void endGame(){
		//minigameStart = false;
		//fishObject.SetActive (!fishObject.activeSelf);
		Destroy (this.gameObject);
	}
}
