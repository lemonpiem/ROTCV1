using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [SerializeField] protected Transform playerTransform;
    private float SpeedToLook = 3;


    protected void Start()
    {
        PlayerFind();
    }
    void Update()
    {
        LookAtPlayer();
    }

    protected void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, SpeedToLook * Time.deltaTime);
    }

    protected void PlayerFind()
    {
        playerTransform = GameObject.Find("Player Cirilla").GetComponent<Transform>();
    }
}

