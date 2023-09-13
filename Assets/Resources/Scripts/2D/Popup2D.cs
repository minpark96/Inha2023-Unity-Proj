using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup2D : MonoBehaviour
{
    public Toggle toggleBGM = null;

    public GameObject radioGroupObj = null;
    Toggle[] toggleRadio;

    void Start()
    {
        toggleRadio = radioGroupObj.GetComponentsInChildren<Toggle>();
    }

    void Update()
    {
        
    }

    void onClickOK()
    {
        Debug.Log("onClickOK()");
    }
    void onClickCancel()
    {
        Debug.Log("onClickCancel()");
        gameObject.SetActive(false);
    }

    public void onToggleBGM()
    {
        if (toggleBGM.isOn)
        {
            Debug.Log("BGM On !!");
        }
        else
        {
            Debug.Log("BGM Off !!");
        }
    }

    public void onToggleRadio()
    {
        if (toggleRadio == null) return;

        if (toggleRadio[0].isOn)
        {
            Debug.Log("1번 선택");
        }
        else if (toggleRadio[1].isOn)
        {
            Debug.Log("2번 선택");
        }
    }
}
