using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    [SerializeField]
    uint _id;

    [SerializeField]
    bool _isUsing;

    public uint Id { get { return _id; } set { _id = value; } }
    public bool IsUsing { get { return _isUsing; } set { _isUsing = value; } }
}
