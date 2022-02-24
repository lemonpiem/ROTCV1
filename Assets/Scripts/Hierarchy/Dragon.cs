using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemies
{

    [SerializeField] private DragonInfo data;
    [SerializeField] private int damage;
    [SerializeField] private int health;

    new

        // Start is called before the first frame update
        void Start()
    {
        PlayerFind();
        damage = data.damage;
        health = data.health;
       
    }

    new

        // Update is called once per frame
        void Update()
    {
        LookAtPlayer();
    }
}
