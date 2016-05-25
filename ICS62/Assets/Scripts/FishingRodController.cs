using UnityEngine;
using System.Collections;

public class FishingRodController : MonoBehaviour {

    Animator anim;

    private bool isCast;
    private bool inWater;
    private GameObject RodCast;
    private bool hasBite;
    private bool gameStarted;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isCast = false;
        inWater = false;
        hasBite = false;
        gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("RodCast(Clone)") != null)
        {
            isCast = true;
            RodCast = GameObject.Find("RodCast(Clone)");

            hasBite = RodCast.GetComponent<RodCastInWater>().hasBite;
            gameStarted = RodCast.GetComponent<RodCastInWater>().gameStarted;
        }

        else
        {
            isCast = false;
            inWater = false;
            hasBite = false;
            gameStarted = false;
        }

        anim.SetBool("hasCast", isCast);
        anim.SetBool("inWater", inWater);
        anim.SetBool("hasBite", hasBite);
        anim.SetBool("gameStarted", gameStarted);

        //Debug.Log("isCast == " + isCast.ToString());

    }
}
