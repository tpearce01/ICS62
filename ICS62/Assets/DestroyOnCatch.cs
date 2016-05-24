using UnityEngine;
using System.Collections;

public class DestroyOnCatch : MonoBehaviour {

	//Check what the line collided with
	void OnTriggerEnter(Collider other) {
		//Destroy bobbers that land on the dock
		if (other.CompareTag ("Dock")) {
			//destroyBobber ();
			Destroy (this.gameObject);
		}
	}
}
