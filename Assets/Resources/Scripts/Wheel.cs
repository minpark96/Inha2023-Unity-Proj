using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Wheel : Car
{
    [SerializeField] 
    float WheelSpeed = 300.0f;
    [SerializeField]
    bool isFront = true;
    
    bool isMaxAngle = false;

    Transform _parent;
    Vector3 _localScale;

    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0, -WheelSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0, WheelSpeed * Time.deltaTime, 0);
        }

        if (isFront)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (AngleGap < 0.0f)
                {
                    transform.Rotate(0, -TempAngle, 0, Space.World);
                    isMaxAngle = false;
                }
                else if (isMaxAngle == false && AngleGap > 0.0f) 
                {
                    if (transform.localRotation.eulerAngles.z > 91.0f)
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle - 180, transform.localEulerAngles.z);
                    else
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle, transform.localEulerAngles.z);
                    isMaxAngle = true;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (AngleGap < 0.0f)
                {
                    transform.Rotate(0, TempAngle, 0, Space.World);
                    isMaxAngle = false;
                }
                else if (isMaxAngle == false && AngleGap > 0.0f)
                {
                    if (transform.localRotation.eulerAngles.z > 91.0f)
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle - 180, transform.localEulerAngles.z);
                    else
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle, transform.localEulerAngles.z);
                    isMaxAngle = true;
                }
            }
            Debug.Log(transform.localRotation.eulerAngles.z + " Local!!," + transform.rotation.eulerAngles.z + " World!!");
            Debug.Log("TurnAngle: " + TurnAngle);
            Debug.Log("TempAngle: " + TempAngle);
            Debug.Log("AngleGap: " + AngleGap);
        }
    }
}
