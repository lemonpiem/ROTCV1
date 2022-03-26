using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CiriHealth : MonoBehaviour
{
    public CiriInfo info;
    private CiriAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<CiriAnimation>();
        info.currentHealth = info.maxHealth;
        Debug.Log("Player Health " + info.currentHealth);


    }

    public void TakeDamage(int damage)
    {
        info.currentHealth -= damage;
        Debug.Log("Player Health " + (info.currentHealth -= damage));

        if (info.currentHealth <= 0)
        {
            PlayerDeath();
        }
    }


    private void PlayerDeath()
    {
        anim.CiriDeath();

    }

    public void HealPlayer(int amount)
    {
        info.currentHealth += amount;
        Debug.Log("Player Health " + (info.currentHealth += amount));

        if (info.currentHealth > info.maxHealth)
        {
            info.currentHealth = info.maxHealth;
        }
    }

    public void HealthBar()
    {
        
    }
}
