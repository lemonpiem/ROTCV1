using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionDetection : MonoBehaviour
{
    public Ciri_Attack ca;
    public CiriInfo datos;
    public Test_Monster currentHealth;

    private void Start()
    {
        ca = GameObject.Find("Player Cirilla").GetComponent<Ciri_Attack>();
        currentHealth = GameObject.Find("Monster Blue").GetComponent<Test_Monster>();
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies" && ca.isAttacking)
        {
            
           other.GetComponent<Animator>().SetBool("RecivingDamage", true);
           other.GetComponent<Test_Monster>().TakeDamage(datos.damage);
          
                if (other.GetComponent<Test_Monster>().currentHealth == 0)
                {
                    
                    GetComponent<Animator>().SetBool("IsDead", true);
                    Destroy(this.gameObject);

                    
                }


        }
    }
}
