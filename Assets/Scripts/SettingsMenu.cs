using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button back;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(BackMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Debug.Log("Publisher: OnClick ");
        Debug.Log("Subscriber: BackMenu ");

    }

}
