using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private AudioSource soundPlayer;
    private int addHealth;

    private void Awake()
    {
        addHealth = 20;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player Cirilla")
        {
            soundPlayer.Play();
            other.gameObject.GetComponent<CiriHealth>().HealPlayer(addHealth);
            int currentHealth = other.gameObject.GetComponent<CiriHealth>().info.currentHealth;
            

            Destroy(gameObject);
        }
    }

    
}
