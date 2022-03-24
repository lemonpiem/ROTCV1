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
        //EnemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(swordSound);
        Debug.Log("Attack");
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {

        yield return new WaitForSeconds(1.1f);
        anim.StopAttack();
        canAttack = true;
        isAttacking = false;

    }

    

    



}
