using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCenter2D : MonoBehaviour
{
    [SerializeField]
    GameObject spawner;
    [SerializeField]
    GameObject playerPrefab;

    Player2D player;

    List<Enemy2D> enemies;
    List<EnemyProjectile2D> enemyProjectiles;

    int enemyDamage = 20;
    int projectileDamage = 10;

    void Awake()
    {
        player = playerPrefab.GetComponent<Player2D>();


        CreatePool(); 
        Subscribe();
        StartSpawn();
    }

    void CreatePool()
    {
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Wolf"), 10);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Cloud"), 15);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/PlayerProjectile"), 15);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/WolfProjectile"), 50);
    }

    void Subscribe()
    {
        spawner.GetComponent<Spawner2D>().CreateEnemy -= PushEnemy;
        spawner.GetComponent<Spawner2D>().CreateEnemy += PushEnemy;
    }

    void PushEnemy(Enemy2D enemy)
    {
        enemies.Add(enemy);
        enemy.ID = enemies.Count - 1;

        enemy.Collision -= AttackFromEnemy;
        enemy.Collision += AttackFromEnemy;
        enemy.Dead -= PopEnemy;
        enemy.Dead += PopEnemy;
        enemy.CreateEnemyProjectile -= PushEnemyProjectile;
        enemy.CreateEnemyProjectile += PushEnemyProjectile;
    }

    void PushEnemyProjectile(EnemyProjectile2D enemyProj)
    {
        enemyProjectiles.Add(enemyProj);
        enemyProj.ID = enemyProjectiles.Count - 1;

        enemyProj.Collision -= AttackFromEnemyProjectile;
        enemyProj.Collision += AttackFromEnemyProjectile;
        enemyProj.Dead -= PopEnemyProjectile;
        enemyProj.Dead += PopEnemyProjectile;
    }

    void PopEnemy(Enemy2D enemy)
    {
        enemy.Collision -= AttackFromEnemy;
        enemy.Dead -= PopEnemy;
        enemy.CreateEnemyProjectile -= PushEnemyProjectile;
        enemies.RemoveAt(enemy.ID);
    }

    void PopEnemyProjectile(EnemyProjectile2D enemyProj)
    {
        enemyProj.Collision -= AttackFromEnemyProjectile;
        enemyProj.Dead -= PopEnemyProjectile;
        enemyProjectiles.RemoveAt(enemyProj.ID);
    }

    void AttackFromEnemy()
    {
        player.Hurt(enemyDamage);
    }

    void AttackFromEnemyProjectile()
    {
        player.Hurt(projectileDamage);
    }

    void StartSpawn()
    {
        StartCoroutine(spawner.GetComponent<Spawner2D>().SpawnWolf());
        StartCoroutine(spawner.GetComponent<Spawner2D>().SpawnCloud());
    }
}
