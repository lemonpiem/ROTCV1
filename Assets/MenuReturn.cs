using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReturn : MonoBehaviour
{

    public GameObject creditsUI;
    
    // Start is called before the first frame update
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
}
