using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile2D : MonoBehaviour
{
    public delegate void OnDead(PlayerProjectile2D playerProj);
    public event OnDead Dead;

    float _moveSpeed = 100f;
    private PlayerProjectile2D thisPlayerProj;

    void Start()
    {
        thisPlayerProj = GetComponent<PlayerProjectile2D>();
    }

    void OnEnable()
    {
        if (GameCenter2D.State == GameCenter2D.GameState.Play)
        {
            StartCoroutine(Death());
        }
    }

    void OnDisable()
    {
        if (GameCenter2D.State == GameCenter2D.GameState.Play)
        {
            Dead(thisPlayerProj);
        }
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
