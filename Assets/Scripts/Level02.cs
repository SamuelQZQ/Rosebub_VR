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
    public Stack<GameObject> targetStack;
    public bool wolfEat;
    public int num = 0;
    public bool isSucceed = false;
    //static public Level02 instance;

	// Use this for initialization
	void Start () {
        //instance = this;
        pickUpFood = false;
        wolfEat = false;
        //wolf = GameObject.FindGameObjectWithTag("Wolf");
        player = GameObject.FindGameObjectWithTag("Player");
        targetStack.Push(player);
	}
	
    public void getFood(GameObject foo){
        food = foo;
        pickUpFood = true;
        targetStack.Push(foo);
    }
    //static public Level02 GetInstance()
    //{
    //    return instance;
    //}
    public void destroyFood()
    {
        Destroy(food);
        wolf.GetComponent<AnimalAIControl>().SetTarget(player.transform);
        targetStack.Pop();
        num++;
    }
   
   
	// Update is called once per frame
	void Update () {
        if (pickUpFood )
        {
            wolf.GetComponent<AnimalAIControl>().SetTarget(targetStack.Peek().transform);
            wolf.SetActive(true);
                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }
        if (num >= 7)
        {
            isSucceed = true;
        }
    }
}
