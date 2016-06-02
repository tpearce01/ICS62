using UnityEngine;
using System.Collections;

public class FishBucket : MonoBehaviour {
		

	public GameObject bucket;

	void OnCollisionEnter(Collision other)
		{
		//if collision with dock, move this object above the bucket
		if (other.collider.CompareTag ("Dock")) {
			this.gameObject.transform.localScale = new Vector3 (.2f, .2f, .2f);
			this.transform.position = new Vector3(36.47f, 2.5f,-3.92f);

		}
	}
}

