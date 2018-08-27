using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class WolfAttack : MonoBehaviour {


    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            WolfController wolf = GetComponent<WolfController>();
            wolf.Attack1 = true;    
        }

        if (collision.collider.tag == "Hand")
        {
            GetComponent<Rigidbody>().AddForce(collision.relativeVelocity);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            WolfController wolf = GetComponent<WolfController>();
            wolf.Attack1 = false;
        }


    }

}
