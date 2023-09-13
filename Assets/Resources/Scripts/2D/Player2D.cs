using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    float maxSpeed = 1000f;
    int hp = 100;
    //private static int numProjectiles = 0;
    //public static int NumProjectiles { get { return numProjectiles; } }
    //new SpriteRenderer renderer;

    public Image imgHPBar = null;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //renderer = GetComponent<SpriteRenderer>();
        Init();

        ShowHPBar(hp);
    }

    public void Hurt(int damage)
    {
        hp -= damage;
        ShowHPBar(hp);
    }

    void ShowHPBar (int hp)
    {
        imgHPBar.fillAmount = (float)hp / (float) 100;
    }

    void OnKeyboard()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Move(x, y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        Managers.Resource.Instantiate("2D/PlayerProjectile", transform).transform.position = transform.position;
    }

    void Init()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }

    //void Flip_2D(float x)
    //{
    //    if (Mathf.Abs(x) > 0)
    //    {
    //        if (x >= 0)
    //            renderer.flipX = false;
    //        else
    //            renderer.flipX = true;
    //    }
    //}

    void Move(float x, float y)
    {
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(
            position.x + (x * maxSpeed * Time.deltaTime),
            position.y + (y * maxSpeed * Time.deltaTime),
            position.z
            );

        rigidBody.MovePosition(position);
    }
}
