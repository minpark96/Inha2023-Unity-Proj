using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int WallCount;
    public GameObject WallPrefab;
    public GameObject EndPrefab;
    public float Interval = 2.0f;

    bool _isStart = false;

    IEnumerator Start()
    {
        while (true)
        {
            if (_isStart)
            {
                WallCount++;
                Debug.Log("WallCount: " + WallCount);
                float randNum = Random.Range(-4.0f, 4.0f);
                Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + randNum, transform.position.z);
                Instantiate(WallPrefab, spawnPos, transform.rotation);
                yield return new WaitForSeconds(Interval);
                if (WallCount > 10)
                {
                    Instantiate(EndPrefab , transform.position, transform.rotation);
                };
            }
            else
            {
                yield return new WaitForSeconds(5);
                _isStart = true;
            }
        }
    }
}
