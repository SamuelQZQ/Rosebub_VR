using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;
using MalbersAnimations.Utilities;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour {

    static LevelOne instance;
    public GameObject wolf;
    public GameObject player;

    public bool wolfSaved = false;
    public GameObject trap, trapOpen;

    public bool wolfFailed = false;
    public GameObject leave;


    public static LevelOne GetIns()
    {
        return instance;
    }


	// Use this for initialization
	void Start () {
        instance = this;
        wolf.GetComponent<WolfController>().Action = true;
        wolf.GetComponent<LookAt>().Target = player.transform;
        wolf.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
    int count = 0;
    float fightTime = 0;
	void Update () {
		

        if(wolfSaved)
        {
            fightTime += Time.deltaTime;
            if(count == 0)
            {
                count++;
                wolf.GetComponent<AnimalAIControl>().target = player.transform;
                wolf.GetComponent<WolfController>().Action = false;
                trap.SetActive(false);
                trapOpen.SetActive(true);
                wolf.GetComponent<WolfController>().Attack1 = true;    
            }
            else if(count == 1)
            {
                wolf.GetComponent<WolfController>().Attack1 = false;    
            }

        }

        if (fightTime > 60) 
        {
            wolfFailed = true;
            fightTime = 0;
        }
        if(wolfFailed)
        {
            fightTime += Time.deltaTime;
            wolf.GetComponent<AnimalAIControl>().target = leave.transform;
        }

        if (fightTime > 10)
        {
            SceneManager.LoadScene("MainScene_2");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
