using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Car
{
    [SerializeField] 
    float WheelSpeed = 300.0f;
    [SerializeField]
    float SpinSpeed = 100.0f;
    [SerializeField]
    bool isFront = true;

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
        float rotW = WheelSpeed * Time.deltaTime;

        if (isFront)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (TurnAngle >= 60.0f)
                {
                    //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 60.0f, transform.eulerAngles.z);
                }
                else
                {
                    transform.RotateAround(transform.position, Vector3.down, Time.deltaTime * SpinSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if(TurnAngle <= -60.0f)
                {
                    //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, -60.0f, transform.eulerAngles.z);
                }
                else
                {
                    transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * SpinSpeed);
                }
            }

            Debug.Log(transform.localRotation.eulerAngles.y + " rotation");
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.down, rotW);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up, rotW);
        }
    }
}
