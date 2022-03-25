using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Attack : MonoBehaviour
{

    public DragonInfo dragonInfo;
    public CiriInfo playerInfo;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Player Cirilla")
            Debug.Log("La colisión funciona");
        {
            var healthComponent = collision.gameObject.GetComponent<CiriHealth>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(dragonInfo.attackDamage);
                Debug.Log("Player Health " + (playerInfo.currentHealth -= dragonInfo.attackDamage));

            }
        }
    }
}
