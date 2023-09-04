using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        //this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();
        Move_Control();
    }

    void Move_Control()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
        }
        
    }

    void Move_1()
    {
        float moveDelta = this.MoveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }

    void Move_2()
    {
        float moveDelta = this.MoveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);
    }
}
