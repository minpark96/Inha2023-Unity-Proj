using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Speed = 30.0f;

    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.eulerAngles = new Vector3 (0.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate_4();
        Rotate_4();
    }

    void Rotate_Around()
    {
        float rot = Speed * Time.deltaTime;
        //transform.RotateAround(, Vector3.up, rot);
        transform.RotateAround(target.transform.position, Vector3.up, rot);
    }

    void Rotate_1()
    {
        Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        this.transform.rotation = target;
    }

    void Rotate_2()
    {
        this.transform.Rotate(Vector3.up * 45.0f);
    }

    void Rotate_3()
    {
        float rot = Speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);
    }

    void Rotate_4()
    {
        float rot = Speed * Time.deltaTime;
        //transform.Rotate(rot * Vector3.up);
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * rot);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(Vector3.down * rot);
        }

    }
}
