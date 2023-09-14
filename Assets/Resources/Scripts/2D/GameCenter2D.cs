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
    [SerializeField]
    List<PlayerProjectile2D> playerProjectiles = new List<PlayerProjectile2D>();
    [SerializeField]
    List<Enemy2D> enemies = new List<Enemy2D>();
    [SerializeField]
    List<EnemyProjectile2D> enemyProjectiles = new List<EnemyProjectile2D>();

    int enemyDamage = 20;
    int projectileDamage = 10;

    int enemyPoolSize = 15;
    int cloudPoolSize = 15;
    int enemyProjectilePoolSize = 50;
    int playerProjectilePoolSize = 30;

    public enum GameState
    {
        Ready,
        Play,
        Pause,
        Over,
    }

    public static GameState State = GameState.Ready;

    void Awake()
    {
        player = playerPrefab.GetComponent<Player2D>();

        Subscribe(); 
        CreatePool();

        State = GameState.Play;
        StartSpawn();
    }

    void CreatePool()
    {
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Wolf"), enemyPoolSize);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/Cloud"), cloudPoolSize);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/WolfProjectile"), enemyProjectilePoolSize);
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>($"Prefabs/2D/PlayerProjectile"), playerProjectilePoolSize);

    }

    void Subscribe()
    {
        spawner.GetComponent<Spawner2D>().CreateEnemy -= PushEnemy;
        spawner.GetComponent<Spawner2D>().CreateEnemy += PushEnemy;
        player.Shoot -= PushPlayerProjectile;
        player.Shoot += PushPlayerProjectile;
    }

    void PushPlayerProjectile(PlayerProjectile2D playerProj)
    {
        playerProjectiles.Add(playerProj);

        playerProj.Dead -= PopPlayerProjectile;
        playerProj.Dead += PopPlayerProjectile;
        Debug.Log("�÷��̾� ����ü ���� �� �����Ϸ�");
        Debug.Log("���� �÷��̾� ����ü ����: " + player.NumProjectiles);
    }

    void PushEnemy(Enemy2D enemy)
    {
        enemies.Add(enemy);

        enemy.Collision -= AttackFromEnemy;
        enemy.Collision += AttackFromEnemy;
        enemy.Dead -= PopEnemy;
        enemy.Dead += PopEnemy;
        enemy.CreateEnemyProjectile -= PushEnemyProjectile;
        enemy.CreateEnemyProjectile += PushEnemyProjectile;
        Debug.Log("�� ���� �� �����Ϸ�");
    }

    void PushEnemyProjectile(EnemyProjectile2D enemyProj)
    {
        enemyProjectiles.Add(enemyProj);

        enemyProj.Collision -= AttackFromEnemyProjectile;
        enemyProj.Collision += AttackFromEnemyProjectile;
        enemyProj.Dead -= PopEnemyProjectile;
        enemyProj.Dead += PopEnemyProjectile;
        Debug.Log("�� ����ü ���� �� �����Ϸ�");
    }

    void PopPlayerProjectile(PlayerProjectile2D playerProj)
    {
        playerProj.Dead -= PopPlayerProjectile;

        uint targetId = playerProj.transform.GetComponent<Poolable>().Id;
        for (int i = 0; i < playerProjectiles.Count; i++)
        {
            uint id = playerProjectiles[i].transform.GetComponent<Poolable>().Id;
            if (targetId == id)
                playerProjectiles.RemoveAt(i);
        }
        player.NumProjectiles--;
        Debug.Log("�÷��̾� ����ü ���� �� ������ҿϷ�");
        Debug.Log("���� �÷��̾� ����ü ����: " + player.NumProjectiles);
    }

    void PopEnemy(Enemy2D enemy)
    {
        enemy.Collision -= AttackFromEnemy;
        enemy.Dead -= PopEnemy;
        enemy.CreateEnemyProjectile -= PushEnemyProjectile;

        uint targetId = enemy.transform.GetComponent<Poolable>().Id;
        for (int i = 0; i < enemies.Count; i++)
        {
            uint id = enemies[i].transform.GetComponent<Poolable>().Id;
            if (targetId == id)
                enemies.RemoveAt(i);
        }
        Debug.Log("�� ���� �� ������ҿϷ�");
    }

    void PopEnemyProjectile(EnemyProjectile2D enemyProj)
    {
        enemyProj.Collision -= AttackFromEnemyProjectile;
        enemyProj.Dead -= PopEnemyProjectile;

        uint targetId = enemyProj.transform.GetComponent<Poolable>().Id;
        for (int i = 0; i < enemyProjectiles.Count; i++)
        {
            uint id = enemyProjectiles[i].transform.GetComponent<Poolable>().Id;
            if (targetId == id)
                enemyProjectiles.RemoveAt(i);
        }
        Debug.Log("�� ����ü ���� �� ������ҿϷ�");
    }

    void AttackFromEnemy()
    {
        player.Hurt(enemyDamage);
        Debug.Log("�� �浹 ������: " + enemyDamage);
    }

    void AttackFromEnemyProjectile()
    {
        player.Hurt(projectileDamage);
        Debug.Log("�� ����ü �浹 ������: " + projectileDamage);
    }

    void StartSpawn()
    {
        StartCoroutine(spawner.GetComponent<Spawner2D>().SpawnWolf());
        StartCoroutine(spawner.GetComponent<Spawner2D>().SpawnCloud());
    }
}
