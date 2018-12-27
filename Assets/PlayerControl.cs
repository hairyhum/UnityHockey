using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Blue,
    Orange
}

public class PlayerControl : MonoBehaviour {

    public float AngularSpeed;
    public float Speed;
    public bool Controlled = false;
    public Team Team = Team.Blue;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().centerOfMass = new Vector2(0.0f, 0.0f);
        if(Team == Team.Blue){
            GetComponent<SpriteRenderer>().color = Color.blue;
        } else if (Team == Team.Orange) {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
	}
	
	// Update is called once per frame
	void Update () {
        var toggleControl = Input.GetButtonDown(TeamControl("ToggleControl"));
        if(toggleControl){
            Controlled = !Controlled;
        }

	}

    void FixedUpdate()
    {
        if (Controlled)
        {
            var move = Input.GetAxis(TeamControl("Vertical"));
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, move * Speed);

            var rotate = Input.GetAxis(TeamControl("Horizontal"));
            GetComponent<Rigidbody2D>().angularVelocity = rotate * AngularSpeed;
        }
    }

    string TeamControl(string control){
        switch(Team){
            case Team.Blue:
                return control + "_p1";
            case Team.Orange:
                return control + "_p2";
            default:
                throw new Exception("Team must be defined");
        }
    }
}