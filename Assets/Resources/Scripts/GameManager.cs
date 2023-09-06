using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << :

public class GameManager : MonoBehaviour
{
    private static GameManager s_Instance;
    public static GameManager Instance 
    { 
        get 
        {
            if (s_Instance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                s_Instance = newGameObject.AddComponent<GameManager>();
            }
            return s_Instance; 
        } 
    }

    public int changeScene = 0;

    private void Awake()
    {
        if(s_Instance != null && s_Instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        s_Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene()
    {
        int scene = changeScene++ % 2;
        //string sceneName = string.Format("Scene_ {0:2d}", scene);
        SceneManager.LoadScene(scene);
    }

    public void ChangeScene(string sceneName)
    {
        //string sceneName = string.Format("Scene_ {0:2d}", scene);
        SceneManager.LoadScene(sceneName);
    }
}
