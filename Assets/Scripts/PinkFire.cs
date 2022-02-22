using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkFire : MonoBehaviour
{
    [SerializeField]private Score sc;

    private void Start()
    {
        sc = GameObject.Find("Score").GetComponent<Score>();
        Debug.Log("este es el score"+ sc);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player Cirilla")
        {
            sc.TrackScore(1);
            Destroy(gameObject);
        }
    }

}
