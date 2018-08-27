using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class Level02 : MonoBehaviour {

    public GameObject playerHand;
    public GameObject[] foods;
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
        foods = GameObject.FindGameObjectsWithTag("Food");
	}
	
    public void getFood(){
        pickUpFood = true;
    }
    //static public Level02 GetInstance()
    //{
    //    return instance;
    //}
    public void destroyFood()
    {
        Destroy(foods[num]);
        num++;
    }
   
   
	// Update is called once per frame
	void Update () {
        if (pickUpFood && num<7)
        {
            wolf.GetComponent<AnimalAIControl>().SetTarget(foods[num].transform);
            wolf.SetActive(true);
                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }
        
    }
}
