using UnityEngine;
using System.Collections;

public class FishingRodController : MonoBehaviour {

    Animator anim;

    private bool isCast;
    private bool inWater;
    private GameObject RodCast;
    private bool hasBite;
    private bool reeling;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isCast = false;
        inWater = false;
        hasBite = false;
        reeling = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("RodCast(Clone)") != null)
        {
            isCast = true;
            RodCast = GameObject.Find("RodCast(Clone)");
            //Debug.Log("isCast == true");
            hasBite = RodCast.GetComponent<RodCastInWater>().hasBite;
        }

        else
        {
            isCast = false;
            inWater = false;
            hasBite = false;

        }

        if (GameObject.Find("Reel(Clone)") != null)
        {
            reeling = true;
            //Debug.Log("reeling == true");
        }

        else
        {
            reeling = false;
        }

        anim.SetBool("hasCast", isCast);
        anim.SetBool("inWater", inWater);
        anim.SetBool("hasBite", hasBite);
        anim.SetBool("reeling", reeling);

        //Debug.Log("isCast == " + isCast.ToString());

    }
}
