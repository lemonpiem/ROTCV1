using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller instance;
    public Transform mainCanvas;

    void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }

        instance = this; 

    }

    public PopUp createPopUp()
    {
        GameObject popUpGO = Instantiate(Resources.Load ("UI/UI_Prefab/PopUP") as GameObject);
        return popUpGO.GetComponent<PopUp>();
    }
}
