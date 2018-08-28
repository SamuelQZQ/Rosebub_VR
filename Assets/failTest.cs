using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wolf")
        {
            GameObject.Find("control").GetComponent<Level02>().fail = true;
        }
    }
    // Update is called once per frame

    void Update () {
		
	}
}
