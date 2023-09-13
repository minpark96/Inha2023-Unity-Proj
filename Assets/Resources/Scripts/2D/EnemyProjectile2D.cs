using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile2D : MonoBehaviour
{
    public delegate void OnCollision();
    public event OnCollision Collision;

    public delegate void OnDead(EnemyProjectile2D enemyProj);
    public event OnDead Dead;

    [SerializeField]
    int id;

    public int ID { get { return id; } set { id = value; } }

    float _moveSpeed = 100f;
    private EnemyProjectile2D thisEnemyProj;

    void Start()
    {
        thisEnemyProj = GetComponent<EnemyProjectile2D>();
    }

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
        if (collision.CompareTag("Player"))
        {
            Collision();
            Dead(thisEnemyProj);
            Managers.Resource.Destroy(this.gameObject);
        }
        else if (collision.CompareTag("PlayerProjectile") || collision.CompareTag("Finish"))
        {
            Dead(thisEnemyProj);
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
