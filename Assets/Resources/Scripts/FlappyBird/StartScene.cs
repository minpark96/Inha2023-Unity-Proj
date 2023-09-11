using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    GameObject _StartMenu;

    [SerializeField]
    Button _ButtonStart;
    [SerializeField]
    Button _ButtonExit;

    void Start()
    {
        _StartMenu = GameObject.Find("StartMenu");

        _ButtonStart = _StartMenu.transform.GetChild(0).GetComponent<Button>();
        _ButtonStart.onClick.AddListener(() => GameManager.Instance.ChangeNextScene());
        _ButtonExit = _StartMenu.transform.GetChild(1).GetComponent<Button>();
        _ButtonExit.onClick.AddListener(() => Application.Quit());
    }
}
