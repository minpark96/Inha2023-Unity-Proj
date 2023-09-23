using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow3D : MonoBehaviour
{
    Vector3 coinPosition;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(coinPosition);
    }

    public void UpdateCoinPosition(Vector3 pos)
    {
        coinPosition = new Vector3(pos.x, transform.position.y, pos.z);
    }
}
