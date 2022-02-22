using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    private float SpeedToLook = 3;
    public float MinDistance;
    public float Speed = 2f;
    private MonsterAnimation anim;


    public enum EnemyType
    {
        Enemy1,
        Enemy2,
    }

    [SerializeField] private EnemyType enemyType;

    private void Start()
    {
        anim = GetComponent<MonsterAnimation>();
    }

    void Update()
    {
        MovementSelection(enemyType);
    }

    private void MovementSelection(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Enemy1:
                EnemyBehaviour();
                break;

            case EnemyType.Enemy2:
                Vector3 vectorPlayer = GetPlayerVector();

                if (MustMove(vectorPlayer))
                {
                
                    Move(vectorPlayer);
                    anim.Run();
                }
                LookAtPlayer();
                break;

        }
    }


    private void EnemyBehaviour()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, SpeedToLook * Time.deltaTime);
    }


    private Vector3 GetPlayerVector()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;

        return direction;
    }

    private void Move(Vector3 vectorPlay)
    {
        transform.Translate(vectorPlay.normalized * Speed * Time.deltaTime, Space.World);
        anim.Run();
    }

    private bool MustMove(Vector3 vectorPlay)
    {
        return vectorPlay.magnitude > MinDistance;
        
        
    }
    private void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, SpeedToLook * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player Cirilla")
        {
           
            anim.Shout();
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player Cirilla")
        {
            anim.Run();

        }
    }

    



}
