using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Information")]
    [SerializeField] private gameState currentState;
    [Header("Items Recoleted")]
    bool gameHasEnded;
    public float restartDelay = 4f;
    public float lastLevelDelay = 10f;
    

    bool lvl1complete;
  
    public static GameManager instance;

    public enum gameState
    {
        MainMenu,
        Play,
        Pause,
        LVL1,
        LVL2,
        LVL3,
        Credits,
        GameOver,

    }

    void Awake()
    {
        if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    { 
     switch (currentState)
        {
            case gameState.MainMenu:
                break;
            case gameState.Play:
                
                break;
            case gameState.Pause:
                
                break;
            case gameState.LVL1:
                FindObjectOfType<AudioManager>().Play("Level1_MainTheme");
                
                break;
            case gameState.LVL2:
                
                break;
            case gameState.LVL3:
                
                break;
            case gameState.Credits:
                
                break;
            case gameState.GameOver:
                GameHasEnded();
                
                break;

        }
        
    }

    public void SetCurrentState(gameState newCurrentState)
    {
        currentState = newCurrentState;
    }

    public void GameHasEnded()
    {

        SetCurrentState(gameState.GameOver);

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            

            Invoke("Restart", restartDelay);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Lvl1Complete()
    {
        
        Invoke("LoadLevel2", restartDelay);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync(3);
        SetCurrentState(gameState.LVL2);
    }

    public void Lvl2Complete()
    {
       
        Invoke("LoadLevel3", restartDelay);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadSceneAsync(4);
        SetCurrentState(gameState.LVL3);
    }

    public void Lvl3Complete()
    {
        
        Invoke("LoadCredits", lastLevelDelay);
    }

    public void LoadCredits()
    {
        SceneManager.LoadSceneAsync(5);
        SetCurrentState(gameState.Credits);
    }


}


