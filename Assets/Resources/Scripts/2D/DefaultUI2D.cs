using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUI2D : MonoBehaviour
{
    public GameObject popupObj = null;
    void Start()
    {
        if (popupObj)
            popupObj.SetActive(false);
    }

    void Update()
    {
        
    }

    void onPopup()
    {
        if (popupObj == null) return;

        if (popupObj.activeSelf)
        {
            popupObj.SetActive(false);
        }
        else
        {
            popupObj.SetActive(true);
        }
    }
}
