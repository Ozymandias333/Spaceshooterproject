using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private float hp = 10;
    [SerializeField] private float hp_max = 10;
    [SerializeField] private float score = 0;
    [SerializeField] private Slider Healthbar;
    [SerializeField] private Text Scorebar;
    [SerializeField] private GameObject Panel;
    public TextMeshProUGUI GameOverText;
    [SerializeField] public Button retry;

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
        TakeDamage(0);
        Score(0);
        Heal(0);
        GameOverText.gameObject.SetActive(false);
        retry.onClick.AddListener(ReturnMainMenu);

    }
    public void ReturnMainMenu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ShowGameOverScreen()
    {
        GameOverText.gameObject.SetActive(true);
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        PauseMenu.instance.StopMusic();
    }

    public void TakeDamage(int damages)
    {
        hp -= damages;
        Healthbar.value = hp / (float)hp_max;
        Update();
    }

    public void Heal(int heal)
    {
        hp += heal;
        Update();
    }

    public void Score(int extra_score)
    {
        score += extra_score;
        Scorebar.text = "Score :" + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp, 0, hp_max);
        if (hp == 0)
        {
            ShowGameOverScreen();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //gameObject other = collision.gameObject;
        if (collision.gameObject.tag == "Heal")
        {
            Heal(5);
        }
    }
}