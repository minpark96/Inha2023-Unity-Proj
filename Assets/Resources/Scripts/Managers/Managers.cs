using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement; // << :

public class Managers : MonoBehaviour
{
    static Managers s_Instance;
    
    public static Managers Instance { get { Init(); return s_Instance; } }

    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();

    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    //public static Managers Instance 
    //{ 
    //    get 
    //    {
    //        if (s_Instance == null)
    //        {
    //            GameObject newGameObject = new GameObject("@GameManager");
    //            s_Instance = newGameObject.AddComponent<GameManager>();
    //        }
    //        return s_Instance; 
    //    } 
    //}

    private void Awake()
    {
        Init();

        //if (s_Instance != null && s_Instance != this) 
        //{ 
        //    Destroy(this.gameObject);
        //    return;
        //}

        //s_Instance = this;

        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Input.OnUpdate();
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();

            s_Instance._pool.Init();
        }
    }

    public int SceneNums = 0;

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
