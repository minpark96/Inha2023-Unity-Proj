using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Car
{
    [SerializeField]
    bool _isFront = true;

    float _wheelSpeed = 0.0f;
    bool _isMaxAngle = false;

    Car _parentCar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("Car");
        _parentCar = go.GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        _wheelSpeed = -_parentCar.Speed * 100.0f;
        transform.Rotate(0, _wheelSpeed * Time.deltaTime, 0);

        if (_isFront)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Wheel TurnAngle: " + _parentCar.TurnAngle);
                Debug.Log("Wheel TempAngle: " + _parentCar.TempAngle);
                if (_isMaxAngle == false)
                {
                    if (AngleGap > 0.0f)
                    {
                        if (transform.localRotation.eulerAngles.z >= 180.0f)
                        {
                            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _parentCar.TurnAngle - 180, transform.localEulerAngles.z);
                        }
                        else
                        {
                            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _parentCar.TurnAngle, transform.localEulerAngles.z);
                        }
                        _isMaxAngle = true;
                    }
                    else
                    {
                        transform.RotateAround(transform.parent.position, transform.parent.up, -_parentCar.TempAngle);
                    }
                }
                else
                {
                    if (AngleGap < 0.0f)
                    {
                        transform.RotateAround(transform.parent.position, transform.parent.up, -_parentCar.TempAngle);
                        _isMaxAngle = false;
                    }
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("Wheel TurnAngle: " + _parentCar.TurnAngle);
                Debug.Log("Wheel TempAngle: " + _parentCar.TempAngle);
                if (_isMaxAngle == false)
                {
                    if (AngleGap > 0.0f)
                    {
                        if (transform.localRotation.eulerAngles.z >= 180.0f)
                        {
                            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _parentCar.TurnAngle - 180, transform.localEulerAngles.z);
                        }
                        else
                        {
                            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _parentCar.TurnAngle, transform.localEulerAngles.z);
                        }
                        _isMaxAngle = true;
                    }
                    else
                    {
                        transform.RotateAround(transform.parent.position, transform.parent.up, _parentCar.TempAngle);
                    }
                }
                else
                {
                    if (AngleGap < 0.0f)
                    {
                        transform.RotateAround(transform.parent.position, transform.parent.up, _parentCar.TempAngle);
                        _isMaxAngle = false;
                    }
                }
            }
        }
    }
}
