using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3D : MonoBehaviour
{
    public List<GameObject> coins = new List<GameObject>();
    public GameObject spawnedCoin = null;

    void Start()
    {
        Init();
        Coin3D co = spawnedCoin.GetComponent<Coin3D>();
        co. += ASDASD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            coins.Add(coin);
            coin.SetActive(false);
        }

        int index = Random.Range(0, coins.Count);

        coins[index].SetActive(true);
        spawnedCoin = coins[index];
    }

    void ASDASD()
    {

    }
}
