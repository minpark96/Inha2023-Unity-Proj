using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public delegate void OnCollision();
    public event OnCollision Collision;

    public delegate void OnDead(Enemy2D enemy);
    public event OnDead Dead;

    public delegate void OnCreateEnemyProjectile(EnemyProjectile2D enemyProjectile);
    public event OnCreateEnemyProjectile CreateEnemyProjectile;

    [SerializeField]
    int id;

    public int ID { get { return id; } set { id = value; } }

    private Rigidbody2D rigidBody;
    private Enemy2D thisEnemy;
    float maxSpeed = 200f;

    void Start()
    {
        thisEnemy = GetComponent<Enemy2D>();
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
            GameObject go = Managers.Resource.Instantiate("2D/WolfProjectile", transform);
            go.transform.position = transform.position;
            EnemyProjectile2D enemyProj = go.GetComponent<EnemyProjectile2D>();
            CreateEnemyProjectile(enemyProj);
            yield return new WaitForSeconds(randTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collision();
            Dead(thisEnemy);
            Managers.Resource.Destroy(this.gameObject);
        }
        else if (collision.CompareTag("PlayerProjectile") || collision.CompareTag("Finish"))
        {
            Dead(thisEnemy);
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
