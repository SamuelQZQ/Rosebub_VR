using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;


public class WolfController : MonoBehaviour {

    private iMalbersInputs character;
    public bool Attack1;
    public bool Attack2;
    public bool Action;
    public bool Jump;
    public bool Fly;
    public bool Down;
    public bool Dodge;
    public bool Stun;
    public bool Death;
    public bool Damaged;
	// Use this for initialization
	void Start () {
        character = GetComponent<iMalbersInputs>();
	}
	
	// Update is called once per frame
	void Update () {
        character.Attack1 = Attack1;
        character.Attack2 = Attack2;        //Get the Attack1 button
        character.Action = Action;  //Get the Action/Emotion button
        character.Jump = Jump;
        character.Down = Down;
        character.Dodge = Dodge;
        character.Stun = Stun;
        character.Death = Death;            //Get the Death button change the variable entry to manipulate how the death works
        character.Damaged = Damaged;
	}
}
