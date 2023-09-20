using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin3D : MonoBehaviour
{
    public Action OnCollisionPlayer;
    public Action OnCollisionEnemy;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCollisionPlayer();
        }
        else if(collision.CompareTag("Enemy"))
        {
            OnCollisionEnemy();
        }
    }
}
