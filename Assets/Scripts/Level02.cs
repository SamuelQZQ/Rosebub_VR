using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;
using UnityEngine.SceneManagement;
public class Level02 : MonoBehaviour {
    public GameObject player;
    public GameObject playerHand;
    public GameObject food;
    public GameObject wolf;
    public bool pickUpFood;
    public Stack<GameObject> targetStack = new Stack<GameObject>();
    public bool wolfEat;
    public int num = 0;
    public bool isSucceed = false;
    float time = 0;
    //static public Level02 instance;

	// Use this for initialization
	void Start () {
        //instance = this;
        pickUpFood = false;
        wolfEat = false;
        //wolf = GameObject.FindGameObjectWithTag("Wolf");
        player = GameObject.FindGameObjectWithTag("Player");
        targetStack.Push(player.gameObject);
	}
	
    public void getFood(GameObject foo){
        food = foo;
        pickUpFood = true;
        targetStack.Push(foo.gameObject);
    }
    //static public Level02 GetInstance()
    //{
    //    return instance;
    //}
    public void destroyFood()
    {
        food = targetStack.Peek();
        wolf.GetComponent<AnimalAIControl>().SetTarget(player.transform);
        targetStack.Pop();
        num++;
        Destroy(food);
    }
   
   
	// Update is called once per frame
	void Update () {
        if (targetStack.Count == 0)
        {
            targetStack.Push(player.gameObject);
        }
        if (pickUpFood && targetStack.Count>0 )
        {
            wolf.GetComponent<AnimalAIControl>().SetTarget(targetStack.Peek().gameObject.transform);
            wolf.SetActive(true);
                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }
        if (num >= 7)
        {
            isSucceed = true;
            Debug.Log("succeed");
        }
        if (isSucceed)
        {
            time += Time.deltaTime;
        }
        if(time>=3)
            SceneManager.LoadScene("level3");//括号内加入场景名字
    }
}

