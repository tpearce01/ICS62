using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

/*
 * PlayerController
 * 
 * Controls player movement
 */ 
public class PlayerController : MonoBehaviour {

	public float speed;

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
				



	}


}
	
