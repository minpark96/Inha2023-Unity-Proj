using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public delegate void Callback_OnTrigger(GameObject other);
    event Callback_OnTrigger onTrigger;

    public float JumpPower = 5.0f;

    bool _isStart = false;

    IEnumerator Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(5);
        _isStart = true;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
        if (_isStart)
        {
            transform.localRotation = Quaternion.Euler(-transform.position.y * 10, 90, 0);
            
            Debug.Log(Time.timeScale);
            if (Time.timeScale > 0.5f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, JumpPower, 0);
                }
            }
        }
    }

    public void SetCallback(Callback_OnTrigger callback_onTrigger)
    {
        if (onTrigger != null)
        {
            Debug.LogWarning("Callback �̹� ������!");
            return;
        }
        onTrigger = callback_onTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Collider �浹 " + hitObject.name + "�� trigger ����");        
        onTrigger?.Invoke(hitObject);
    }
}
