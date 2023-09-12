using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public void OnUpdate()
    {
        // Ű���� �Է¸�
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();
    }

    public void Clear()
    {
        KeyAction = null;
    }
}
