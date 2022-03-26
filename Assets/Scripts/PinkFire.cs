using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PinkFire : MonoBehaviour

{
    
    [SerializeField] private Score sc;
    [SerializeField] private AudioClip magicFire;
    [SerializeField] private AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        sc = GameObject.Find("Score").GetComponent<Score>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Player Cirilla")
        {
            aS.PlayOneShot(magicFire);
            sc.TrackScore(1);
            Destroy(gameObject);
        }
    }

}
