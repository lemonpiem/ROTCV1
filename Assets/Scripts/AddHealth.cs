using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
   
    private int addHealth;

    private void Awake()
    {
        addHealth = 20;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player Cirilla")
        {
            FindObjectOfType<AudioManager>().Play("AddHealth");
            other.gameObject.GetComponent<CiriHealth>().HealPlayer(addHealth);
            float currentHealth = other.gameObject.GetComponent<CiriHealth>().info.currentHealth;
            

            Destroy(gameObject);
        }
    }

    
}
