using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScene : MonoBehaviour
{
    [SerializeField]
    GameObject _ClearMenu;

    [SerializeField]
    Button _ButtonTryAgain;
    [SerializeField]
    Button _ButtonMainMenu;

    void Start()
    {
        _ClearMenu = GameObject.Find("ClearMenu");

        _ButtonTryAgain = _ClearMenu.transform.GetChild(0).GetComponent<Button>();
        _ButtonTryAgain.onClick.AddListener(() => Managers.Instance.ChangePrevScene());
        _ButtonMainMenu = _ClearMenu.transform.GetChild(1).GetComponent<Button>();
        _ButtonMainMenu.onClick.AddListener(() => Managers.Instance.ChangeNextScene());
    }
}
