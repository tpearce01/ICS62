using UnityEngine;
using System.Collections;

public class Persist : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		if (GameObject.FindGameObjectsWithTag("BGM").Length > 1){
			Destroy(this.gameObject);
		}
		else {
			DontDestroyOnLoad(transform.gameObject);
		}

	}
	

}
