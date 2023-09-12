using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    float maxSpeed = 200f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(
            position.x - (maxSpeed * Time.deltaTime),
            position.y,
            position.z
            );

        rigidBody.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Finish"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
