using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Managers.Instance.ChangeNextScene();
        }
        
        if (Input.GetMouseButton(1))
        {
            if (Managers.Instance.SceneNums == 0)
            {
                Managers.Instance.ChangeScene("99_End");
                Managers.Instance.SceneNums++;
            }
            else if (Managers.Instance.SceneNums == 1)
            {
                Managers.Instance.ChangeScene("03_Collision");
                Managers.Instance.SceneNums++;
            }
        }
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(100,200,200,30), "¾À º¯°æ"))
        {
            if (Managers.Instance.SceneNums == 0)
            {
                Managers.Instance.ChangeScene("99_End");
                Managers.Instance.SceneNums++;
            }
            else if (Managers.Instance.SceneNums == 1)
            {
                Managers.Instance.ChangeScene("03_Collision");
                Managers.Instance.SceneNums++;
            }
        }
    }
}
