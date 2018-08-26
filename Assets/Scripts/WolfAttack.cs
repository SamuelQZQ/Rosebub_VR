using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class WolfAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        WolfController wolf = collision.collider.GetComponentInParent<WolfController>();
        if(wolf.tag == "Wolf")
        {
            wolf.Attack1 = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        WolfController wolf = collision.collider.GetComponentInParent<WolfController>();
        if (wolf.tag == "Wolf")
        {
            wolf.Attack1 = false;
        }
    }

}
