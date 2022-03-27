using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Dragon : Dragon
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    private Transform player;

    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private bool alreadyAttacked;

    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    [SerializeField] private DragonAnimation anim;
    [SerializeField] private  GameObject projectile;
    [SerializeField] private Transform fireLaucher;
    [SerializeField] private AudioClip dragonRoar;
    public AudioSource ac;

    private void Awake()
    {
        player = GameObject.Find("Player Cirilla").transform;
        data.currentHealth = data.maxHealth;
        anim = GetComponent<DragonAnimation>();
        ac = GetComponent<AudioSource>();
    }
    
    new void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        anim.Scream();


        if (!alreadyAttacked)
        {

            anim.FlameAttack();
            ac.PlayOneShot(dragonRoar);

            Rigidbody rb =Instantiate(projectile, fireLaucher.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        data.currentHealth -= damage;

        if (data.currentHealth <= 0)
        {

            Die();

        }
    }
    private void Die()
    {
       anim.DragonDeath();

        this.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void DragonFireFlames()
    {

    }
}
