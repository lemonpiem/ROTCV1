using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Manager : MonoBehaviour
{

    public GameObject popUp;
    public static bool lvl1Started = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PopUp();
    }

    private  void PopUp()
    {
        if (lvl1Started)
        {
            popUp.SetActive(true);
        }
    }

}
