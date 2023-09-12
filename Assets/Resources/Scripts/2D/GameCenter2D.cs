using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCenter2D : MonoBehaviour
{
    [SerializeField]
    GameObject _spawner;

    void Awake()
    {
        CreatePool();
        StartSpawn();
    }

    void CreatePool()
    {
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Wolf"), 10);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Cloud"), 15);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/PlayerProjectile"), 15);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/WolfProjectile"), 50);
    }

    void StartSpawn()
    {
        StartCoroutine(_spawner.GetComponent<Spawner2D>().SpawnWolf());
        StartCoroutine(_spawner.GetComponent<Spawner2D>().SpawnCloud());
    }
}
