using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore1;
    [SerializeField] private int score;

    void Start()
    {
        textScore1 = GameObject.Find("Score1").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrackScore(int score)
    {
        
        IncreaseItems (score);
        
    }

    public void IncreaseItems(int score)
    {

        this.score += score;
        textScore1.text = score.ToString() + " Dragon Flames";
        Debug.Log(score.ToString() + " Dragon Flames");

    }

    
}
