using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemies
{

    [SerializeField] public DragonInfo data;
    [SerializeField] public float damage;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;

    new

        // Start is called before the first frame update
        void Start()
    {
        
        maxHealth = data.maxHealth;
        damage = data.attackDamage;
        currentHealth = data.currentHealth;



    }

    new

        // Update is called once per frame
        void Update()
    {
       
    }
}
