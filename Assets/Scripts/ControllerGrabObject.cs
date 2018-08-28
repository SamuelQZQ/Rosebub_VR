using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    // Use this for initialization
    public GameObject Food;
    public GameObject control;

    public float stunTime;

    private SteamVR_TrackedObject trackedObj;

    // 1
    private GameObject collidingObject;
    // 2    
    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        control = GameObject.FindGameObjectWithTag("control");
        Food = GameObject.FindGameObjectWithTag("Food");
            
    }
    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }


    bool attacked = false;
    float attackedTime = 0;
    private void LateUpdate()
    {
        if (attacked && Time.time - attackedTime >= stunTime)
        {
            attacked = false;
            GameObject.Find("Wolf Cub").GetComponent<WolfController>().Stun = false;
        }
     
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
       // Debug.Log("get");

        if(other.GetComponentInParent<WolfController>())
        {
            Debug.Log("Attcked");
            other.GetComponentInParent<WolfController>().Stun = true;
            attackedTime = Time.time;
            attacked = true;
        }

        if (other.tag == "Trap")
        {
            if (Controller.GetHairTriggerDown())
            {
                LevelOne.GetIns().wolfSaved = true;
            }
        }

    }


    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        Debug.Log(other.tag);
        if (other.tag == "Trap")
        {
            if (Controller.GetHairTriggerDown())
            {
                LevelOne.GetIns().wolfSaved = true;
            }
        }
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }
    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand = null;
    }

    // Update is called once per frame
    void Update () {
        // 1
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
                if (objectInHand.gameObject.tag == "Food")
                {


                    GameObject.FindGameObjectWithTag("control").GetComponent<Level02>().getFood(objectInHand.gameObject);
                    Debug.Log("get food");

                }
                
                
            }
        }

        // 2
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

    }
}
