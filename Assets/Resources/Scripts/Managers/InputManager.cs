using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public void OnUpdate()
    {
        // 키보드 입력만
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();
    }

    public void Clear()
    {
        KeyAction = null;
    }
}
