using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Spawner2D : MonoBehaviour
{
    public delegate void OnCreateEnemy(Enemy2D enemy);
    public event OnCreateEnemy CreateEnemy;

    public IEnumerator SpawnWolf()
    {
        Transform root = new GameObject().transform;
        root.name = $"Wolf_Root";
        while (true)
        {
            float randY = Random.Range(-180, 180);
            Vector2 spawnPos = new Vector2(transform.position.x, randY);
            GameObject go = Managers.Resource.Instantiate("2D/Wolf", root);
            go.transform.position = spawnPos;
            Enemy2D enemy = go.GetComponent<Enemy2D>();
            CreateEnemy(enemy);
            yield return new WaitForSeconds(10.0f);
        }
    }

    public IEnumerator SpawnCloud()
    {
        Transform root = new GameObject().transform;
        root.name = $"Cloud_Root";
        while (true)
        {
            float randY = Random.Range(-180, 180);
            float randTime = Random.Range(1.0f, 5.0f);
            Vector2 spawnPos = new Vector2(transform.position.x, randY);
            Managers.Resource.Instantiate("2D/Cloud", root).transform.position = spawnPos;
            yield return new WaitForSeconds(randTime);
        }
    }
}
