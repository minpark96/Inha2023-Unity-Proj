using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float SpinSpeed = 50.0f;

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
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.left, Time.deltaTime * SpinSpeed);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.right, Time.deltaTime * SpinSpeed);
        }
    }
}
