using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionDetectionDragon : MonoBehaviour
{
    
        public Ciri_Attack ca;
        public CiriInfo datos;
        public Boss_Dragon dragonStats;
        public float currentHealth;

    private void Start()
    {
        ca = GameObject.Find("Player Cirilla").GetComponent<Ciri_Attack>();
        dragonStats = GameObject.Find("Boss").GetComponent<Boss_Dragon>();
    }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemies" && ca.isAttacking)

            {
                
                other.GetComponent<DragonAnimation>().GetHit();
                other.GetComponent<Boss_Dragon>().TakeDamage(datos.damage);
               

            if (other.GetComponent<Boss_Dragon>().data.currentHealth == 0)
                
                {

                    other.GetComponent<DragonAnimation>().DragonDeath();
                   
                }


            }
        }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemies" && ca.isAttacking)

        {

            other.GetComponent<DragonAnimation>().StopAttack();


        }
    }
}

