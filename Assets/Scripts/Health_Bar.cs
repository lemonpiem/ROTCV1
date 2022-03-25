using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour

{
    public CiriInfo info;
    public Slider slider; 
    public CiriAnimation anim;


    private void Start()
    {
        info.currentHealth = info.maxHealth;
        anim = GetComponent<CiriAnimation>();
    }

    private void SetCurrentHealth(int currentHealth)
    { 
        slider.value = currentHealth;
    }

    private void TakeDamagePlayer(int amount)
    {
        info.currentHealth -= amount;

        if (info.currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        anim.CiriDeath();
        

    }

    private void HealPlayer(int amount)
    {
        info.currentHealth += amount;

        if (info.currentHealth > info.maxHealth)
        {
            info.currentHealth = info.maxHealth;
        }
    }
}
