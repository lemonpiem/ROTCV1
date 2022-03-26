using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drowner_Attack : MonoBehaviour
{
    public DrownerInfo drownerInfo;
    public CiriInfo playerInfo;

    

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Player Cirilla")
            
        {
            var healthComponent = collision.gameObject.GetComponent<CiriHealth>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(drownerInfo.attackDamage);
                Debug.Log("Player Health " + (playerInfo.currentHealth -= drownerInfo.attackDamage));

            }
        }



    
    }
}
