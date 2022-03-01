using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemies : MonoBehaviour
{
    public event Action onEnemyBehaviour;

    [SerializeField] protected Transform playerTransform;
    private float SpeedToLook = 3;


    protected void Start()
    {
        InvokerOnEnemyBehaviour();
        onEnemyBehaviour += PlayerFind;
        onEnemyBehaviour += LookAtPlayer;
    }
    protected void Update()
    {
        //LookAtPlayer();
    }

    protected void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, SpeedToLook * Time.deltaTime);
        Debug.Log("Publisher: OnEnemyBehaviour - Subscriber: LookAtPlayer");
    }

    protected void PlayerFind()
    {
        playerTransform = GameObject.Find("Player Cirilla").GetComponent<Transform>();
        Debug.Log("Publisher: OnEnemyBehaviour - Subscriber: PlayerFind");
    }

    protected void InvokerOnEnemyBehaviour()
    {
        onEnemyBehaviour?.Invoke();
    }


   
}

