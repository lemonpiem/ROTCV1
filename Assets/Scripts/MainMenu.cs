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
    

    private void Start()
    {
    
        newGame.onClick.AddListener(PlayGame);
        quitGame.onClick.AddListener(QuitGame);

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

  

}

