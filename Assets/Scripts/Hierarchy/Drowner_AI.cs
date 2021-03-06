using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


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

    [SerializeField] private DrownersKilled dk;
    public AudioClip monsterRoar;
    public AudioSource ac;

    public AudioManager audioManager;






    void Awake()
    {
        player = GameObject.Find("Player Cirilla").transform;
        dk = GameObject.Find("DrownersKilled").GetComponent<DrownersKilled>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<MonsterAnimation>();
      

        info.currentHealth = info.maxHealth;

        
    }


    new void FixedUpdate()
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

            FindObjectOfType<AudioManager>().Play("DrownerScream"); 

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }



    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        anim.StopDrownerAttack();
        
    }

    public void TakeDamage(float damage)
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

        FindObjectOfType<AudioManager>().Play("DrownerDeath");

        dk.IncreaseItems(1);
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





