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
            case gameState.LVL1:
                Debug.Log("Excecute LVL1 tasks");
                break;
            case gameState.LVL2:
                Debug.Log("Excecute LVL1 tasks");
                break;
            case gameState.LVL3:
                Debug.Log("Excecute LVL1 tasks");
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

        SetCurrentState(gameState.GameOver);

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

    public void Lvl1Complete()
    {
        Debug.Log("Loading Level 2");
        Invoke("LoadLevel2", restartDelay);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync(3);
        SetCurrentState(gameState.LVL2);
    }

    public void Lvl2Complete()
    {
        Debug.Log("Loading Level 3");
        Invoke("LoadLevel3", restartDelay);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadSceneAsync(4);
        SetCurrentState(gameState.LVL3);
    }

    

}


