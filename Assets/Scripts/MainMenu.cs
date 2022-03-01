using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;



public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button newGame;
    [SerializeField] private Button quitGame;
    [SerializeField] private Button settingsGame;


    private void Start()
    {
    
        newGame.onClick.AddListener(PlayGame);
        quitGame.onClick.AddListener(QuitGame);
        settingsGame.onClick.AddListener(Settings);


    }

   
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Publisher: OnClick ");
        Debug.Log("Subscriber: Play Game ");
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Publisher: OnClick ");
        Debug.Log("Subscriber: Quit Game ");
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(2);
        Debug.Log("Publisher: OnClick ");
        Debug.Log("Subscriber: Settings ");

    }

}

