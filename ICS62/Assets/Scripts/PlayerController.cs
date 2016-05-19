using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

/*
 * PlayerController
 * 
 * Controls player movement
 */ 
public class PlayerController : MonoBehaviour {

	public float speed;	//Speed of player movement
	public Rigidbody rodCast;
	public int forceToAdd;

	public bool hasCast;

	void Start() {
		hasCast = false;
	}

	//Player movement
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.Q)) {
			transform.position -= transform.right * Time.deltaTime * speed * 0.7f;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= transform.forward * Time.deltaTime * speed / 2;
		}
		if (Input.GetKey (KeyCode.E)) {
			transform.position += transform.right * Time.deltaTime * speed * 0.7f;
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(Vector3.up, -speed * 25 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up, speed * 25 * Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (!hasCast) {
				CastRod ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			//Debug.Log ("Mouse (right) clicked");
		}


	}

	void CastRod () {

		Rigidbody rodCastClone;
		Vector3 direction = this.GetComponentInParent<Transform> ().forward;

		hasCast = true;

		rodCastClone = (Rigidbody) Instantiate (rodCast, this.GetComponentInParent<Transform> ().position + transform.forward, this.GetComponentInParent<Transform> ().rotation);
		rodCastClone.AddForce(transform.forward * forceToAdd);
		rodCastClone.AddForce (transform.up * forceToAdd);


	}


}
	
