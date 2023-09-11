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
                GameObject newGameObject = new GameObject("@GameManager");
                s_Instance = newGameObject.AddComponent<GameManager>();
            }
            return s_Instance; 
        } 
    }

    StateManager _state;
    public StateManager State;

    public int SceneNums = 0;

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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ChangeNextScene()
    {
        int scene = ++SceneNums % 3;
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }

    public void ChangePrevScene()
    {
        int scene = --SceneNums % 3;
        Debug.Log(scene);
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    public void ChangeScene(string sceneName)
    {
        //string sceneName = string.Format("Scene_ {0:2d}", scene);
        SceneManager.LoadScene(sceneName);
    }
}
