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
            GameManager.Instance.ChangeNextScene();
        }
        
        if (Input.GetMouseButton(1))
        {
            if (GameManager.Instance.SceneNums == 0)
            {
                GameManager.Instance.ChangeScene("99_End");
                GameManager.Instance.SceneNums++;
            }
            else if (GameManager.Instance.SceneNums == 1)
            {
                GameManager.Instance.ChangeScene("03_Collision");
                GameManager.Instance.SceneNums++;
            }
        }
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(100,200,200,30), "¾À º¯°æ"))
        {
            if (GameManager.Instance.SceneNums == 0)
            {
                GameManager.Instance.ChangeScene("99_End");
                GameManager.Instance.SceneNums++;
            }
            else if (GameManager.Instance.SceneNums == 1)
            {
                GameManager.Instance.ChangeScene("03_Collision");
                GameManager.Instance.SceneNums++;
            }
        }
    }
}
