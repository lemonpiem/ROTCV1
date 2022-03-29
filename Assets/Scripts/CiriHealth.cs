using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CiriHealth : MonoBehaviour
{
    public CiriInfo info;
    private CiriAnimation anim;
    public Image healthbar;
    
    

    // Start is called before the first frame update
    void Start()
    {

        

        anim = GetComponent<CiriAnimation>();
        info.currentHealth = info.maxHealth;
        HealthBarFill();
        //Debug.Log("Player Health " + info.currentHealth);




    }

    public void TakeDamage(int damage)
    {
        
            info.currentHealth -= damage;
            HealthBarFill();
            //Debug.Log("Player Health " + (info.currentHealth -= damage));

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
        HealthBarFill();
        //Debug.Log("Player Health " + info.currentHealth);   

        if (info.currentHealth > info.maxHealth)
        {
            info.currentHealth = info.maxHealth;
        }
    }

    public void HealthBarFill()
    {
        float hbFillAmount = info.currentHealth / info.maxHealth;
        
        healthbar.fillAmount = hbFillAmount;
    }


}
