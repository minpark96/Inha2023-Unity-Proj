using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float _acceleration = 1.0f;
    float _brakingPower = 5.0f;
    float _turnSpeed = 100.0f;

    float _turnAngle = 0.0f;
    public float TurnAngle { get { return _turnAngle; } }
    float _angleGap = 0.0f;
    public float AngleGap { get { return _angleGap; } }
    float _tempAngle = 0.0f;
    public float TempAngle { get { return _tempAngle; } }
    float _speed = 0.0f;
    public float Speed { get { return _speed; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move_Control();
    }

    void Move_Control()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (_speed >= 300.0f)
            {
                _speed = 300.0f;
            }
            else
            {
                if (_speed < 0.0f)
                    _speed += _brakingPower * Time.deltaTime;
                else
                    _speed += _acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (_speed <= -100.0f)
            {
                _speed = -100.0f;
            }
            else
            {
                if (_speed > 0.0f)
                    _speed -= _brakingPower * Time.deltaTime;
                else
                    _speed -= _acceleration / 2 * Time.deltaTime;
            }
        }

        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (_speed > 0.0f)
            transform.Rotate(Vector3.up * _turnAngle * Time.deltaTime);
        else
            transform.Rotate(Vector3.down * _turnAngle * Time.deltaTime);
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_turnAngle > -60.0f)
            {
                _tempAngle = _turnSpeed * Time.deltaTime;
                _turnAngle -= _tempAngle;
                _angleGap = -60.0f - _turnAngle;
            }
            else if (_angleGap > 0.0f)
            {
                _turnAngle = -60.0f;
            }

            Debug.Log("Car TurnAngle: " + _turnAngle);
            Debug.Log("Car TempAngle: " + _tempAngle);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_turnAngle < 60.0f)
            {
                _tempAngle = _turnSpeed * Time.deltaTime;
                _turnAngle += _tempAngle;
                _angleGap = _turnAngle - 60.0f;
            }
            else if (_angleGap > 0.0f)
            {
                _turnAngle = 60.0f;
            }

            Debug.Log("Car TurnAngle: " + _turnAngle);
            Debug.Log("Car TempAngle: " + _tempAngle);
        }
    }
}
