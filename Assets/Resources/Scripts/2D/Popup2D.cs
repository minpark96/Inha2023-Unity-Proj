using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup2D : MonoBehaviour
{
    public Text titleText = null;
    public InputField inputText = null;

    public Toggle toggleBGM = null;

    public GameObject radioGroupObj = null;
    Toggle[] toggleRadio;

    void Start()
    {
        titleText = GetComponentInChildren<Text>();
        titleText.text = "뷁";

        toggleRadio = radioGroupObj.GetComponentsInChildren<Toggle>();
    }

    void Update()
    {
        
    }

    void onClickOK()
    {
        Debug.Log("onClickOK()");
        titleText.text = "OK clicked!!";
    }
    void onClickCancel()
    {
        Debug.Log("onClickCancel()");
        gameObject.SetActive(false);
    }

    void onTextChanged()
    {
        titleText.text = inputText.text;
    }

    void onTextEndEdit()
    {
        titleText.text = inputText.text;
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
