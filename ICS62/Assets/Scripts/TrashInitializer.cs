using UnityEngine;
using System.Collections;

public class TrashInitializer : MonoBehaviour {

	int randomize;
	float x;
	float z;
	float yRot;

	public GameObject trashPrefab;	//coke
	public GameObject trashPrefab2;	//plastic
	public GameObject trashPrefab3;	//water jug

	private GameObject trashCopy;
	//private GameObject trashCopy2;
	//private GameObject trashCopy3;
	private GlobalVariablesScript globalVars;

	void Start(){
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();

		for (int i = 0; i < globalVars.trashInWater; i++) {

			randomize = (int) Random.Range (0.0f, 2.9f);


			//randomize x and z position from (25,-90) to (-60,90)
			x = Random.Range (-60.0f, 25.0f);
			z = Random.Range (-90.0f, 90.0f);

			//randomize rotation in water
			yRot = Random.Range(0.0f, 350.0f);
			switch (randomize) {
			case 0:
				trashCopy = (GameObject)Instantiate (trashPrefab, new Vector3 (x, -2.0f, z), Quaternion.identity/*Euler(new Vector3(0,yRot,-70))*/);
				trashCopy.transform.Rotate (-70, yRot, 0);
				break;
			case 1:
				trashCopy = (GameObject) Instantiate (trashPrefab2, new Vector3(x, -1.0f, z), Quaternion.identity/*Euler(new Vector3(0,yRot,-70))*/);
				trashCopy.transform.Rotate (-70, yRot, 0);
				break;
			case 2:
				trashCopy = (GameObject) Instantiate (trashPrefab3, new Vector3(x, 0.0f, z), Quaternion.identity/*Euler(new Vector3(0,yRot,15))*/);
				trashCopy.transform.Rotate (0, yRot, 15);
				break;
			default:
				Debug.Log ("Error in assigning prefab to trash");
				break;
			}
			//trashCopy = (GameObject) Instantiate (trashPrefab, new Vector3(x, y, z), Quaternion.Euler(new Vector3(0,yRot,-70)));

		}
	}

	public void DestroyTrash(){
		Destroy (GameObject.FindGameObjectWithTag ("Trash"));
	}
}
