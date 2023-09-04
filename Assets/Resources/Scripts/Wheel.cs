using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float Speed = 100.0f;
    public bool isFront = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float rotX = Speed * Time.deltaTime;

        if (isFront)
        {
            float rotY = Speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
            {
                transform.RotateAround(this.transform.position, Vector3.up, rotY);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.RotateAround(this.transform.position, Vector3.down, rotY);
            }
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.RotateAround(this.transform.position, Vector3.right, rotX);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.RotateAround(this.transform.position, Vector3.left, rotX);
        }
    }
}
