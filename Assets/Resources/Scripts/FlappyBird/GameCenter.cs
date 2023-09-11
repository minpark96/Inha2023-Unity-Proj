using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCenter : MonoBehaviour
{
    bool _isPause;

    [SerializeField]
    GameObject _PauseMenu;
    [SerializeField]
    GameObject _GameOverMenu;

    [SerializeField]
    Button _ButtonResume;
    [SerializeField]
    Button _ButtonRestart;

    [SerializeField]
    Button _ButtonTryAgain;
    [SerializeField]
    Button _ButtonMainMenu;

    [SerializeField]
    Text _TextCountdown;
    [SerializeField]
    FlappyBird _player;

    private void Start()
    {
        _player = GameObject.Find("Dragon").GetComponent<FlappyBird>();
        _player.SetCallback(OnTrigger_Player);

        _TextCountdown = GameObject.Find("TextCountdown").GetComponent<Text>();
        StartCoroutine(CountDownCoroutine(5));

        _isPause = false;
        _PauseMenu = GameObject.Find("PauseMenu");

        _ButtonResume = _PauseMenu.transform.GetChild(0).GetComponent<Button>();
        _ButtonResume.onClick.AddListener(() => Resume());
        _ButtonRestart = _PauseMenu.transform.GetChild(1).GetComponent<Button>();
        _ButtonRestart.onClick.AddListener(() => GameManager.Instance.Restart());
        _PauseMenu.SetActive(false);

        _GameOverMenu = GameObject.Find("GameOverMenu");

        _ButtonTryAgain = _GameOverMenu.transform.GetChild(0).GetComponent<Button>();
        _ButtonTryAgain.onClick.AddListener(() => GameManager.Instance.Restart());
        _ButtonMainMenu = _GameOverMenu.transform.GetChild(1).GetComponent<Button>();
        _ButtonMainMenu.onClick.AddListener(() => GameManager.Instance.ChangePrevScene());
        _GameOverMenu.SetActive(false);

        Spawner.WallCount = 0;
        Debug.Log("Start!!!!!");
    }

    IEnumerator CountDownCoroutine(int value)
    {
        Debug.Log("코루틴 시작!!");

        for (int i = value; i > 0; i--)
        {
            Debug.Log("Count: " + i);
            _TextCountdown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        _TextCountdown.text = "GO!";
        yield return new WaitForSeconds(1);
        _TextCountdown.transform.gameObject.SetActive(false);
    }

    void OnTrigger_Player(GameObject other)
    {
        Debug.Log(other.name);
        CheckClear(other);
    }

    void CheckClear(GameObject other)
    {
        if (other.name == "End(Clone)")
        {
            GameClear();
        }
        else
        {
            GameOver();
        }
    }

    void GameClear()
    {
        GameManager.Instance.ChangeNextScene();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        _GameOverMenu.SetActive(true);
    }

    void Update()
    {
        TogglePause();
    }

    void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPause == false)
            {
                _PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }

            _isPause = !_isPause;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _isPause = false;
        _PauseMenu.SetActive(false);
    }

    //private void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //private void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    Debug.Log("OnSceneLoaded: " + scene.name);
    //    Debug.Log(mode);

    //    _isPause = false;
    //    _PauseMenu = GameObject.Find("PauseMenu");
    //    _ButtonResume = _PauseMenu.transform.GetChild(0).GetComponent<Button>();
    //    _ButtonResume.onClick.AddListener(() => Resume());
    //    _ButtonRestart = _PauseMenu.transform.GetChild(1).GetComponent<Button>();
    //    _ButtonRestart.onClick.AddListener(() => GameManager.Instance.Restart());
    //    _PauseMenu.SetActive(false);
    //}
}
