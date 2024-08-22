using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the game Object reaches the edges it will be destroyed (player and enemies)
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
