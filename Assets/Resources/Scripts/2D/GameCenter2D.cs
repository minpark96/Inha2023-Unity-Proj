using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCenter2D : MonoBehaviour
{
    [SerializeField]
    GameObject _spawner;
    GameObject _player;

    List<GameObject> _enemies;

    void Awake()
    {
        CreatePool();
        StartSpawn();

        _spawner.GetComponent<Spawner2D>().Create -= PushEnemy;
        _spawner.GetComponent<Spawner2D>().Create += PushEnemy;
    }

    void CreatePool()
    {
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Wolf"), 10);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Cloud"), 15);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/PlayerProjectile"), 15);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/WolfProjectile"), 50);
    }

    void PushEnemy(GameObject go)
    {
        _enemies.Add(go);
    }

    void StartSpawn()
    {
        StartCoroutine(_spawner.GetComponent<Spawner2D>().SpawnWolf());
        StartCoroutine(_spawner.GetComponent<Spawner2D>().SpawnCloud());
    }
}
