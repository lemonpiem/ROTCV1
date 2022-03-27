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
  
    public static GameManager instance;

    public enum gameState
    {
        MainMenu,
        Play,
        Pause,
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
                Debug.Log("Excecute Play tasks");
                break;
            case gameState.Pause:
                Debug.Log("Excecute Pause tasks");
                break;
            case gameState.GameOver:
                GameHasEnded();
                Debug.Log("Excecute GameOver tasks");
                break;

        }
        
    }

    public void SetCurrentState(gameState newCurrentState)
    {
        currentState = newCurrentState;
    }

    public void GameHasEnded()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");

            Invoke("Restart", restartDelay);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}


