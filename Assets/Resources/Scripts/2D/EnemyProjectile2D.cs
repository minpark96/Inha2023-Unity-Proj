using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile2D : MonoBehaviour
{
    float _moveSpeed = 100f;

    void OnEnable()
    {
        StartCoroutine(Death());
    }

    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(4.0f);
        Managers.Resource.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Finish"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
