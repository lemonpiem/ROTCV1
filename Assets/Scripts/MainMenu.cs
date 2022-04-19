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
    [SerializeField] private Button credits;


    private void Start()
    {
    
        newGame.onClick.AddListener(PlayGame);
        quitGame.onClick.AddListener(QuitGame);
        settingsGame.onClick.AddListener(Settings);
        credits.onClick.AddListener(Credits);

    }

   
    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(2);
        

    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync(5);


    }


}

