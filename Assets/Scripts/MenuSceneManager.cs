using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public static MenuSceneManager instance = null;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] public Button buttonPlay, buttonCredits, buttonQuit;
    public string sceneToLoad;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Pause();
        buttonPlay.onClick.AddListener(Resume);
        buttonQuit.onClick.AddListener(QuitMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        /*pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;*/
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PauseMenu");
    }

    public void QuitMenu()
    {
        Application.Quit();
        //GameManager.instance.ShowGameOverScreen();
    }
}
