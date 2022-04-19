using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drowner_Attack : MonoBehaviour
{
    public DrownerInfo drownerInfo;
    public CiriInfo playerInfo;

    

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player Cirilla")
            
        {
            
            CiriHealth healthComponent = other.gameObject.GetComponent<CiriHealth>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(drownerInfo.attackDamage);

            }
        }



    
    }
}
