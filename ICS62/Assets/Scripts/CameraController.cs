using UnityEngine;
using System.Collections;

/*
 * CameraController
 * 
 * Controls camera movement. Camera will follow the player.
 */
public class CameraController: MonoBehaviour {

	public GameObject player;
	
	private Vector3 offset;
	private float offsetMagnitude;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		offsetMagnitude = offset.magnitude;
	}

	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = player.transform.rotation;	//match rotation of player
		transform.position = player.transform.position - transform.forward * 4 + transform.up * 2;	//match position of player
		transform.LookAt (player.transform.position);
	}
}
