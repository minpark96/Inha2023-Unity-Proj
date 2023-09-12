using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Spawner2D : MonoBehaviour
{
    public IEnumerator SpawnWolf()
    {
        Transform root = new GameObject().transform;
        root.name = $"Wolf_Root";
        while (true)
        {
            float randY = Random.Range(-180, 180);
            Vector2 spawnPos = new Vector2(transform.position.x, randY);
            Transform myTransform = Managers.Resource.Instantiate("2D/Wolf", root).transform;
            myTransform.transform.position = spawnPos;
            StartCoroutine(SpawnEnemyProjectile(myTransform));
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

    public IEnumerator SpawnEnemyProjectile(Transform parent)
    {
        while (true)
        {
            float randTime = Random.Range(2.0f, 4.0f);
            Managers.Resource.Instantiate("2D/WolfProjectile", parent).transform.position = parent.position;
            yield return new WaitForSeconds(randTime);
        }
    }
}
