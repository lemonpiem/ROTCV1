using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI textScore1;
    [SerializeField] private int score;

    void Awake()
    {
        instance = this;
        
    }


    public void TrackScore(int score)
    {
        
        IncreaseItems (score);
        
    }

    public void IncreaseItems(int score)
    {

        this.score += score;
        textScore1.text = this.score.ToString() + " Dragon Flames";

    }

    
}
