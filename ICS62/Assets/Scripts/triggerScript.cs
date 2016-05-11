using UnityEngine;
using System.Collections;

public class triggerScript : MonoBehaviour {

	private PlayerBarController barController;

	void Start(){
		barController = GameObject.FindGameObjectWithTag ("PlayerBar").GetComponent<PlayerBarController> ();
	}

	void FixedUpdate(){
		transform.position = barController.gameObject.transform.position;
	}

	void OnTriggerEnter2D (Collider2D other){
		Debug.Log ("trigger enter " + other.tag);
		if(other.CompareTag("FishIcon")){
			Debug.Log ("isOverlapping");
			barController.isOverlapping = true;
		}
	}
		

	void OnTriggerExit2D (Collider2D other){
		Debug.Log ("trigger exit " + other.tag);
		if (other.CompareTag ("FishIcon")) {
			Debug.Log ("!isOverlapping");
			barController.isOverlapping = false;
		}
	}
}
