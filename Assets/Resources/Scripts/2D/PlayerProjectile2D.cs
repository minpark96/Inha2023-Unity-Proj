using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile2D : MonoBehaviour
{
    float _moveSpeed = 100f;

    void OnEnable()
    {
        StartCoroutine(Death());
    }

    void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(4.0f);
        Managers.Resource.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyProjectile"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
