using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public delegate void OnAttack();
    public event OnAttack Attack;

    private Rigidbody2D rigidBody;
    float maxSpeed = 200f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        StartCoroutine(SpawnProjectile());
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

    public IEnumerator SpawnProjectile()
    {
        while (true)
        {
            float randTime = Random.Range(2.0f, 4.0f);
            Managers.Resource.Instantiate("2D/WolfProjectile", transform).transform.position = transform.position;
            yield return new WaitForSeconds(randTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
            Managers.Resource.Destroy(this.gameObject);
        }
        else if (collision.CompareTag("PlayerProjectile") || collision.CompareTag("Finish"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
