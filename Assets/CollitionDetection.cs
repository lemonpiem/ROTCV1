using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionDetection : MonoBehaviour
{
    public GameObject hitBlood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            other.GetComponent<Animator>().SetBool("RecivingDamage", true);
            Instantiate(hitBlood, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}
