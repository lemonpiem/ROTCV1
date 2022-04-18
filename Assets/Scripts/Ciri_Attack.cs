using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciri_Attack : MonoBehaviour
{
    public GameObject sword;
    [SerializeField] private CiriInfo datos;
    [SerializeField] private CiriAnimation anim;
    private bool canAttack;
    public bool isAttacking;
    [SerializeField] private bool EnemyInAttackRange;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask whatIsEnemy;
    public AudioClip swordSound;

    private void Start()
    {
        anim = GetComponent<CiriAnimation>();
        canAttack = true;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (canAttack)
            {
                SwordAttack();
                
            }
            
        }
    }

    private void SwordAttack()
    {
        canAttack = false;
        anim.Attack();
        isAttacking = true;
        AudioSource aS = GetComponent<AudioSource>();
        aS.PlayOneShot(swordSound);
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {

        StartCoroutine(ResetIsAttacking());
        yield return new WaitForSeconds(1.1f);
        anim.StopAttack();
        canAttack = true;
        

    }

    private IEnumerator ResetIsAttacking()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

  
   








}
