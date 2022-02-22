using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Information")]
    [SerializeField] private gameState currentState;
    [Header("Items Recoleted")]
    [SerializeField] private int Score;
    [SerializeField] private TextMeshProUGUI textScore1;

    public enum gameState
    {
        Play,
        Pause,
        GameOver,
    }

    public static GameManager instance; 

    void Awake()
    {
        if (instance!=null && instance!= this)
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
            case gameState.Play:
                Debug.Log("Excecute Play tasks");
                break;
            case gameState.Pause:
                Debug.Log("Excecute Pause tasks");
                break;
            case gameState.GameOver:
                Debug.Log("Excecute GameOver tasks");
                break;
        }
        
    }       

    public void IncreaseItems(int score)
    {
        this.Score += score;
        textScore1.text = Score.ToString() + " Dragon Flames";

    }

    public void SetCurrentState (gameState newCurrentState)
    {
        currentState = newCurrentState;
    }
}


