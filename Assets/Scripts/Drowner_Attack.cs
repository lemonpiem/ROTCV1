using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drowner_Attack : MonoBehaviour
{
    public DrownerInfo dinfo;
    public CiriInfo cinfo;

    

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Player Cirilla")
            Debug.Log("COl");
        {
            var healthComponent = collision.gameObject.GetComponent<CiriHealth>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(dinfo.attackDamage);
                Debug.Log("Player Health " + (cinfo.currentHealth -= dinfo.attackDamage));

            }
        }



    
    }
}
