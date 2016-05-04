using UnityEngine;
using System.Collections;

public class PlayerBarController : MonoBehaviour {
	public int forceToAdd;
	private GameObject thisObject;
	private Rigidbody2D thisRB;
	private bool minigameStart;
	private RodCastInWater bobberScript;

	// Use this for initialization
	void Start () {
		minigameStart = false;
		thisObject = this.gameObject;
		thisRB = thisObject.GetComponent<Rigidbody2D> ();
		bobberScript = GameObject.FindGameObjectWithTag ("Bobber").GetComponent<RodCastInWater> ();

		startGame ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Mouse0)){
			Debug.Log ("playerBar registered mouse click");
			thisRB.AddForce(transform.up * forceToAdd);
		}
	}

	public void startGame(){
		minigameStart = true;
//		thisObject.SetActive (!thisObject.activeSelf);
		//disable player controller
	}

	public void endGame() {
		minigameStart = false;
	//	thisObject.SetActive (!thisObject.activeSelf);
		bobberScript.destroyBobber ();
	}
}
