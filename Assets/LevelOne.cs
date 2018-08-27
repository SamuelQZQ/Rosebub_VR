using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;
using MalbersAnimations.Utilities;

public class LevelOne : MonoBehaviour {

    public GameObject wolf;
    public GameObject player;

    public bool wolfSaved = false;
    public GameObject jiazi;

    public bool wolfFailed = false;



	// Use this for initialization
	void Start () {
        wolf.GetComponent<WolfController>().Action = true;
        wolf.GetComponent<LookAt>().Target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(wolfSaved)
        {
            wolf.GetComponent<AnimalAIControl>().target = player.transform;
            jiazi.SetActive(false);


        }

        if(wolfFailed)
        {
            
        }
	}
}
