using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{

    private int addHealth;

    private void Awake()
    {
        addHealth = 50;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player Cirilla")
        {
            other.gameObject.GetComponent<CiriHealth>().HealPlayer(addHealth);
            int currentHealth = other.gameObject.GetComponent<CiriHealth>().info.currentHealth;

            Debug.Log("Heal " + addHealth + " CurrentHealth " + (currentHealth += addHealth));
            Destroy(gameObject);
        }
    }

    
}
