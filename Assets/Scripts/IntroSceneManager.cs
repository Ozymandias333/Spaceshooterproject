using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] public Button TimeToPlay;
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        TimeToPlay.onClick.AddListener(changeScene);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneToLoad); //Change the scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
