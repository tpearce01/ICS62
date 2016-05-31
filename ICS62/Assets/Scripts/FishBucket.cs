using UnityEngine;
using System.Collections;

public class FishBucket : MonoBehaviour {

	void SetTransformY(float n){
		transform.position = new Vector3 (36, n, -3);
	}

	void OnTriggerEnter(Collider other) {
		//If collides with dock
		if (other.CompareTag ("Dock")) {
				//Put Fish in Bucket;
				SetTransformY(3.0f);

	Debug.Log ("Hello");
		
	}
}
}
