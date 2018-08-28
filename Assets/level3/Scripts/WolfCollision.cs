using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        var name = collision.collider.name;
        if(name == "Head")
        {
           // Debug.Log("Fail");
        }
     
    }
}
