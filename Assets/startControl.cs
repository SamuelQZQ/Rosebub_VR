using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//头部引入
 
 
//在你想跳转场景的地方加入下面代码


public class startControl : MonoBehaviour {
   

    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Controller.GetHairTriggerDown())
        {
            SceneManager.LoadScene("Level1");//括号内加入场景名字
        }
	}
}
