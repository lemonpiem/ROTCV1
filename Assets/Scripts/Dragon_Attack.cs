using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Attack : MonoBehaviour
{

    public DragonInfo dragonInfo;
    public CiriInfo playerInfo;

  

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player Cirilla")
        {

            CiriHealth healthComponent = other.gameObject.GetComponent<CiriHealth>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(dragonInfo.attackDamage);
                Destroy(gameObject);
            }
        }
    }
}
