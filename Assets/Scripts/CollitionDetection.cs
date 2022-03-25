using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionDetection : MonoBehaviour
{
    public Ciri_Attack ca;
    public CiriInfo datos;
    public Drowner_AI currentHealth;

    private void Start()
    {
        ca = GameObject.Find("Player Cirilla").GetComponent<Ciri_Attack>();
        currentHealth = GameObject.Find("Drowner").GetComponent<Drowner_AI>();
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies" && ca.isAttacking)
        {
            
           other.GetComponent<Animator>().SetBool("RecivingDamage", true);
           other.GetComponent<Drowner_AI>().TakeDamage(datos.damage);
          
                if (other.GetComponent<Drowner_AI>().info.currentHealth == 0)
                {
                    
                    GetComponent<Animator>().SetBool("IsDead", true);
                    Destroy(this.gameObject);

                    
                }


        }
    }
}