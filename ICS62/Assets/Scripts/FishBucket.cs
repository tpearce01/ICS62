using UnityEngine;
using System.Collections;

public class FishBucket : MonoBehaviour {

	void OnCollisionEnter(Collision other)
		{
		//if collision with dock, move this object above the bucket
		if (other.collider.CompareTag ("Dock")) {
			
			this.transform.position = new Vector3(36.47f, 3.5f,-3.92f);
			this.gameObject.transform.localScale = new Vector3 (.2f, .2f, .2f);

		}
	}
}

