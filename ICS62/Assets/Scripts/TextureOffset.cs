using UnityEngine;
using System.Collections;

public class TextureOffset : MonoBehaviour {

	public float scrollSpeed = -.05f;
	public Renderer rend;

	private float timer;
	bool switcher = true;

	void Start() {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.mainTextureOffset = new Vector2(0,offset);
	}
}
