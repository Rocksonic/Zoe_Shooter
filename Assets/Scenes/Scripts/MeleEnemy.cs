using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public LayerMask whatIsGround, whatIsPlayer;
    public List<GameObject> SkinsEnemyList;
    private GameObject[] SkinsEnemyArray;

    public float damage;
    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Bool Animation
    public bool isPatroling;
    public bool isChasePlayer;
    public bool isHitting;

    private void Awake()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        SkinsEnemyArray = SkinsEnemyList.ToArray();
        SkinsEnemyArray[Random.Range(0, SkinsEnemyArray.Length -1)].SetActive(true);
    }
    // Update is called once per frame
    private void Update()
    {
        
        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        else isPatroling = false;

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        else isChasePlayer = false;

        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        else isHitting = false;
    }

    private void Patroling()
    {
        isPatroling = true;
        agent.speed = 2f;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        isChasePlayer = true;
        agent.speed = 12f;
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        agent.speed = 4f;
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player.transform);

        if (!alreadyAttacked)
        {
        
            RaycastHit hit;
            isHitting = true;
            if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange* 2f))
            {
                hit.transform.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //Debug.Log("estoy recibiendo daño");
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("*procede a morirse*");
        player.gameObject.GetComponent<PlayerController>().kills += 1;
        Destroy(gameObject);
    }
}
