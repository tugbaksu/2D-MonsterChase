using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // when finish every calculations done about update function than call LateUpdate function
    void LateUpdate()
    {
        //if player doesnt exist i mean player destroyed before that than skip this funciton
        if (player == null)
            return;
        

        //camera set - follow the player
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        else if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        transform.position = tempPos;

    }
}
