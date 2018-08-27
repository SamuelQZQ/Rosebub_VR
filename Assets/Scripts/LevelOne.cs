using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;
using MalbersAnimations.Utilities;

public class LevelOne : MonoBehaviour {

    public GameObject wolf;
    public GameObject player;

    public bool wolfSaved = false;
    public GameObject trap;

    public bool wolfFailed = false;
    public GameObject leave;


	// Use this for initialization
	void Start () {
        wolf.GetComponent<WolfController>().Action = true;
        wolf.GetComponent<LookAt>().Target = player.transform;
	}
	
	// Update is called once per frame
    int count = 0;
	void Update () {
		

        if(wolfSaved)
        {
            if(count == 0)
            {
                count++;
                wolf.GetComponent<AnimalAIControl>().target = player.transform;
                wolf.GetComponent<WolfController>().Action = false;
                trap.SetActive(false);
                wolf.GetComponent<WolfController>().Attack1 = true;    
            }
            else if(count == 1)
            {
                wolf.GetComponent<WolfController>().Attack1 = false;    
            }

        }

        if(wolfFailed)
        {
            wolf.GetComponent<AnimalAIControl>().target = leave.transform;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
