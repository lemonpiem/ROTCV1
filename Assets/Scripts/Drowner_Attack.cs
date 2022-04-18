using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drowner_Attack : MonoBehaviour
{
    public DrownerInfo drownerInfo;
    public CiriInfo playerInfo;

    

    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == "Player Cirilla")
            
        {
            Debug.Log("funciona");
            CiriHealth healthComponent = collision.gameObject.GetComponent<CiriHealth>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(drownerInfo.attackDamage);
                

            }
        }



    
    }
}
