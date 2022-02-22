using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI textScore1;

    // Start is called before the first frame update
    void Start()
    {
        //textScore1 = GameObject.Find("Score1").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrackScore(int score)
    {
        
        GameManager.instance.IncreaseItems (score);
        
    }
}
