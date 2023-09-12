using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud2D : MonoBehaviour
{
    float _moveSpeed;

    void Start()
    {
        _moveSpeed = Random.Range(50.0f, 100.0f);
    }

    void Update()
    {
        MoveLeft();      
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
