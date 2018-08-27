using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class Level02 : MonoBehaviour {
    public GameObject player;
    public GameObject playerHand;
    public GameObject food;
    public GameObject wolf;
    public bool pickUpFood;
    public bool wolfEat;
    public int num = 0;
    //static public Level02 instance;

	// Use this for initialization
	void Start () {
        //instance = this;
        pickUpFood = false;
        wolfEat = false;
        //wolf = GameObject.FindGameObjectWithTag("Wolf");
	}
	
    public void getFood(GameObject foo){
        food = foo;
        pickUpFood = true;
    }
    //static public Level02 GetInstance()
    //{
    //    return instance;
    //}
    public void destroyFood()
    {
        Destroy(food);
        wolf.GetComponent<AnimalAIControl>().SetTarget(player.transform);
    }
   
   
	// Update is called once per frame
	void Update () {
        if (pickUpFood )
        {
            wolf.GetComponent<AnimalAIControl>().SetTarget(food.transform);
            wolf.SetActive(true);
                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }
        
    }
}
