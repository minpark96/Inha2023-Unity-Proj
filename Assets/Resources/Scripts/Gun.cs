using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float SpinSpeed = 50.0f;
    Transform _parent;

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
        if (Input.GetKey(KeyCode.C))
        {
            transform.SetParent(null);
            transform.Rotate(Vector3.left, Time.deltaTime * SpinSpeed);
            transform.SetParent(_parent);
            //transform.RotateAround(transform.position, Vector3.left, Time.deltaTime * SpinSpeed);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.SetParent(null);
            transform.Rotate(Vector3.right, Time.deltaTime * SpinSpeed);
            transform.SetParent(_parent);
            //transform.RotateAround(transform.position, Vector3.right, Time.deltaTime * SpinSpeed);
        }
    }
}
