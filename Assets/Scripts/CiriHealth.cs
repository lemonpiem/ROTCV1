using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CiriHealth : MonoBehaviour
{
    public CiriInfo info;
    private CiriAnimation anim;
    public Image healthbar;
    public TextMeshProUGUI healthText;


    void Start()
    {

        

        anim = GetComponent<CiriAnimation>();
        info.currentHealth = info.maxHealth;
        healthText.text = "Health" + info.currentHealth + "/" + info.maxHealth;
        HealthBarFill();
       




    }

    public void TakeDamage(float damage)
    {
        
            info.currentHealth -= damage;
            healthText.text = "Health" + info.currentHealth + "/" + info.maxHealth;
            HealthBarFill();

            if (info.currentHealth <= 0)
            {
                PlayerDeath();
                FindObjectOfType<GameManager>().GameHasEnded();
            }
        
    }


    private void PlayerDeath()
    {
        anim.CiriDeath();

    }

    public void HealPlayer(float amount)
    {
        info.currentHealth += amount;
        healthText.text = "Health" + info.currentHealth + "/" + info.maxHealth;
        HealthBarFill();
         

        if (info.currentHealth > info.maxHealth)
        {
            info.currentHealth = info.maxHealth;
        }
    }

    public void HealthBarFill()
    {
        var hbFillAmount = info.currentHealth / info.maxHealth;
        
        healthbar.fillAmount = hbFillAmount;
    }


}
