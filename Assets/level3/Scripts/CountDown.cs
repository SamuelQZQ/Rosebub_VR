using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using MalbersAnimations;

public class CountDown : MonoBehaviour {
    private float totalTime1 = 5;
    private float intervalTime = 1;

    

    public Text CountDown1Text;

    private bool WolfShow = true;
    private bool WolfArrive = false;

    private float distance = 0.0f;

    GameObject root;
    GameObject point;
    GameObject[] AI;
    GameObject[] escapePoint;
    GameObject player;
    // Use this for initialization
    void Start () {
        //初始化剩余时间
        CountDown1Text.text = string.Format("逃离剩余时间 {0:d2}:{1:d2}", (int)totalTime1 / 60, (int)totalTime1 % 60);
        //找到要隐藏的大狼对象
        root = GameObject.Find("Attacker Wolves/WolfObject/WolfWhiteMagic");
        point = GameObject.Find("Player/point");
        player = GameObject.Find("Player");
        AI = GameObject.FindGameObjectsWithTag("Wolf");
        escapePoint = GameObject.FindGameObjectsWithTag("escapePoint");
        root.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        //倒计时开始
		if(totalTime1 > 0)
        {
            intervalTime += Time.deltaTime;
            if(intervalTime >= 1)
            {
                intervalTime = 0;
                totalTime1--;
                CountDown1Text.text = string.Format("逃离剩余时间 {0:d2}:{1:d2}", (int)totalTime1 / 60, (int)totalTime1 % 60);
            }
        }
        //倒计时结束 群狼停止
        if(totalTime1 <= 0 && WolfShow)
        {
            root.SetActive(true);
            WolfShow = false;
            for (int i = 0; i < AI.Length; i++)
            {
                AI[i].GetComponent<NavMeshAgent>().speed = 0.0f;
            }
        }
        //狼没到达前
        if (!WolfArrive)
        {
            
            distance = Vector3.Distance(point.transform.position, root.transform.position);
            //狼到达后 坏狼跑走
            if(distance < 1)
            {
                for (int i = 0; i < AI.Length; i++)
                {
                    AI[i].GetComponent<AnimalAIControl>().target = escapePoint[i % 4].transform;
                    AI[i].GetComponent<NavMeshAgent>().speed = 0.8f;
                }
                root.GetComponent<AnimalAIControl>().target = player.transform;
                WolfArrive = true;
            }

        }
        

	}
}
