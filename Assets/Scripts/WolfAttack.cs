using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class WolfAttack : MonoBehaviour {

    public float power;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            WolfController wolf = GetComponent<WolfController>();
            wolf.Attack1 = true;    
        }

        if (collision.collider.tag == "Hand")
        {
            Debug.Log("hahahaha");
            GetComponent<Rigidbody>().AddForce(collision.relativeVelocity * power);
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
