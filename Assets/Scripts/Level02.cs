using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class Level02 : MonoBehaviour {

    public GameObject playerHand;
    public GameObject food;
    public GameObject wolf;
    public bool pickUpFood;
    public bool wolfEat;
    //static public Level02 instance;

	// Use this for initialization
	void Start () {
        //instance = this;
        pickUpFood = false;
        wolfEat = false;
        wolf = GameObject.FindGameObjectWithTag("Wolf");
        food = GameObject.FindGameObjectWithTag("Food");
	}
	
    public void getFood(){
        pickUpFood = true;
    }
    //static public Level02 GetInstance()
    //{
    //    return instance;
    //}

   
   
	// Update is called once per frame
	void Update () {
        if (pickUpFood)
        {
            wolf.GetComponent<AnimalAIControl>().target = food.transform;
        }
	}
}
