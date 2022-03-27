using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrownersKilled : MonoBehaviour
{
    public static DrownersKilled instance;
    [SerializeField] private TextMeshProUGUI textScore1;
    [SerializeField] private int kills;

    void Awake()
    {
        instance = this;
    }

    public void TrackKills(int kills)
    {

        IncreaseItems(kills);

    }

    public void IncreaseItems(int kills)
    {

        this.kills += kills;
        textScore1.text = this.kills.ToString();

        if (this.kills == 4)
        {
            FindObjectOfType<GameManager>().Lvl2Complete();
        }

    }
}
