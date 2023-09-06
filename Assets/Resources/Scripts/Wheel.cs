using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Wheel : Car
{
    [SerializeField] 
    float WheelSpeed = 300.0f;
    [SerializeField]
    float SpinSpeed = 100.0f;
    [SerializeField]
    bool isFront = true;

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
                if (transform.rotation.eulerAngles.x >= 90.0f &&
                    transform.rotation.eulerAngles.x <= 270.0f)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle, transform.localEulerAngles.z);
                }
                    
                else
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle, transform.localEulerAngles.z);
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (transform.rotation.eulerAngles.x >= 90.0f &&
                    transform.rotation.eulerAngles.x <= 270.0f)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle, transform.localEulerAngles.z);
                }
                    
                else
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, TurnAngle, transform.localEulerAngles.z);
            }
            Debug.Log(transform.localRotation.eulerAngles.y + " Local!! ," + transform.rotation.eulerAngles.y + " World!!");
        }
    }
}
