using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    [HideInInspector] //public olup eriþilebilecek ancak inspector penceresinde saklanacak
    public float speed;

    private Rigidbody2D myBody;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //not only one effects rigid body gravity or add force
        //instent of add force can be use velocity
        //velocity: pushes the game object (left-right-up-down)
        //vector2(x,y) vector3(x,y,z) axis
        //                            (x axis:effecting by speed,y axis:current velocity)
        myBody.velocity = new Vector2 (speed,myBody.velocity.y);    
    }
}

//Rigid body preferences:

//dynamic-> gravity , force
//kinematic-> only force dosent effect by gravity
//static -> no force no gravity,only wants have rigid body