using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Manager : MonoBehaviour
{

    public GameObject popUp;
    public static bool lvlStarted = true;
    public static bool tutorialClosed;
    public GameObject questPopUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (popUp != null)
        {
            PopUp();
   
        }
        else
        {
            QuestPopUp();
        }

    }

    private void PopUp()
    {
        if (lvlStarted)
        {
            popUp.SetActive(true);
            tutorialClosed = false;

        }
        else
        {
            popUp.SetActive(false);
            tutorialClosed = true;
            GameObject.Destroy(popUp);
            
        }
    }

    private void QuestPopUp()
    {
        if (tutorialClosed == false)
        {
            questPopUp.SetActive(true);
        }
        
    }

}
