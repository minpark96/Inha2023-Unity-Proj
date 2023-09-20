using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3D : MonoBehaviour
{
    public delegate void OnUpdateCoinPosition(GameObject coin);
    public event OnUpdateCoinPosition UpdateCoinPosition;

    public List<GameObject> coins = new List<GameObject>();
    public GameObject spawnedCoin = null;
    Coin3D coin3D;

    private HUD3D HUD;
    private Arrow3D arrow;
    private int currIndex;

    void Start()
    {
        Init();
    }

    void Init()
    {
        HUD = GameObject.Find("HUD").GetComponent<HUD3D>();
        arrow = GameObject.Find("Arrow").GetComponent<Arrow3D>();

        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            coins.Add(coin);
            coin.SetActive(false);
        }

        currIndex = UnityEngine.Random.Range(0, coins.Count);

        spawnedCoin = coins[currIndex];
        spawnedCoin.SetActive(true);

        coin3D = spawnedCoin.GetComponent<Coin3D>();
        coin3D.OnCollisionPlayer -= CollisionPlayer;
        coin3D.OnCollisionPlayer += CollisionPlayer;
        coin3D.OnCollisionEnemy -= CollisionEnemy;
        coin3D.OnCollisionEnemy += CollisionEnemy;
    }

    void CollisionPlayer()
    {
        HUD.UpdatePlayerScore();
        RespawnCoin();
    }

    void CollisionEnemy()
    {
        HUD.UpdateEnemyScore();
        RespawnCoin();
    }

    void RespawnCoin()
    {
        int prevIndex = currIndex;

        do
        {
            currIndex = UnityEngine.Random.Range(0, coins.Count);
        }
        while (prevIndex == currIndex);

        coin3D.OnCollisionPlayer -= CollisionPlayer;
        coin3D.OnCollisionEnemy -= CollisionEnemy;
        spawnedCoin.SetActive(false);

        spawnedCoin = coins[currIndex];
        spawnedCoin.SetActive(true);
        coin3D = spawnedCoin.GetComponent<Coin3D>();
        coin3D.OnCollisionPlayer -= CollisionPlayer;
        coin3D.OnCollisionPlayer += CollisionPlayer;
        coin3D.OnCollisionEnemy -= CollisionEnemy;
        coin3D.OnCollisionEnemy += CollisionEnemy;


    }
}
