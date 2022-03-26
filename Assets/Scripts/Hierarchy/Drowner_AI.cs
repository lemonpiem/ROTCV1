using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Drowner_AI : Enemies
{

    [SerializeField] private NavMeshAgent agent;
    

    [SerializeField] private Transform player;

    [SerializeField] private MonsterAnimation anim;

    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;
    
    public DrownerInfo info;

    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private bool walkPointSet;
    [SerializeField] private float walkPointRange;


    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private bool alreadyAttacked;
    

    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    public AudioClip monsterRoar;
    public AudioSource ac;



    void Awake()
    {
        player = GameObject.Find("Player Cirilla").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<MonsterAnimation>();
        ac = GetComponent<AudioSource>();

        info.currentHealth = info.maxHealth;

        
    }


    new void Update()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
            anim.Run();

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.Run();
    }

    private void AttackPlayer()
    {

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            anim.DrownerAttack();
            //ac.PlayOneShot(monsterRoar);


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
        info.currentHealth -= damage;

        if (info.currentHealth <= 0)
        {
            
            Die();

        }
    }
    private void Die()
    {
        anim.Death();
        

        this.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        StartCoroutine(DestroyGO());
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    
}


