using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFire : MonoBehaviour
{
    private CiriAnimation anim;
    [SerializeField] public Score sc;


    private void Start()

    {
        anim = GetComponent<CiriAnimation>();
        sc = GameObject.Find("Score").GetComponent<Score>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player Cirilla")
        {

            //sc.TrackScore(1);
            Destroy(gameObject);
            

        }
    }

    




}
