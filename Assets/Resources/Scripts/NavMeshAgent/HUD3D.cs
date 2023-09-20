using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD3D : MonoBehaviour
{
    int playerScore = 0;
    int enemyScore = 0;

    TMP_Text textPlayerScore;
    TMP_Text textEnemyScore;

    public GameObject Spawner;

    void Start()
    {
        Spawner3D spawner3D = Spawner.GetComponent<Spawner3D>();

        GameObject PlayerScore = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        GameObject EnemyScore = transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        textPlayerScore = PlayerScore.GetComponent<TMP_Text>();
        textEnemyScore = EnemyScore.GetComponent<TMP_Text>();
    }

    public void UpdatePlayerScore()
    {
        playerScore += 1;
        textPlayerScore.text = playerScore.ToString();
    }

    public void UpdateEnemyScore()
    {
        enemyScore += 1;
        textEnemyScore.text = enemyScore.ToString();
    }
}
