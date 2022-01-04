using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance = null;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] public Button buttonPlay, buttonCredits, buttonQuit;
    [SerializeField] public AudioSource playSound;
    public TextMeshProUGUI CreditsText;

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
        CreditsText.gameObject.SetActive(false);
        Pause();
        buttonPlay.onClick.AddListener(Resume);
        buttonQuit.onClick.AddListener(QuitMenu);
        buttonCredits.onClick.AddListener(Credits);
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

        if (Input.GetKey(KeyCode.Escape))
        {
            CreditsText.gameObject.SetActive(false);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        playSound.Play();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        playSound.Pause();
    }

    public void Credits()
    {
        StopMusic();
        pauseMenuUI.SetActive(false);
        CreditsText.gameObject.SetActive(true);
    }
    /*public void LoadMenu()
    {
        Time.timeScale = 1f;    
        SceneManager.LoadScene("PauseMenu");
    }*/

    public void QuitMenu()
    {
        Application.Quit();
        //GameManager.instance.ShowGameOverScreen();
    }

    public void StopMusic()
    {
        playSound.Stop();
    }
}
