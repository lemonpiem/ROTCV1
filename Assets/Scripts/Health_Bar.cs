using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour

{
    public CiriInfo info;
    public Image image;
    
   
    private void Awake()
    {
        image = GetComponent<Image>();
        info.currentHealth = info.maxHealth;
        
    }

    private void Update()
    {
        image.fillAmount = info.currentHealth / info.maxHealth;
    }


}
