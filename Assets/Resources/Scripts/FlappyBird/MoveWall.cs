using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(4.0f);
        Death();
    }

    //void Start()
    //{
    //    Invoke("Death", 3.0f);
    //}

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
}
