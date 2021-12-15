using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.UI;

public class ShooterEnemy : MonoBehaviour
{
    // publics GameObject 
    public Slider healSlider;
    public NavMeshAgent agent;
    public GameObject player;
    public LayerMask whatIsGround, whatIsPlayer;
    public List<GameObject> SkinsEnemyList;
    private GameObject[] SkinsEnemyArray;
    private float maxHealth;
    

    public float health;
    public float damage;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;
    public bool muerto;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool canDestroyBullet;

    //Bool Animation
    public bool isPatroling;
    public bool isChasePlayer;
    public bool isShoting;
    public bool isTakingDamage;
    public bool isDead;

    private void Awake()
    {

        isPatroling = false;
        isChasePlayer = false;
        isShoting = false;

        canDestroyBullet = false;
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

        SkinsEnemyArray = SkinsEnemyList.ToArray();

        SkinsEnemyArray[Random.Range(0, SkinsEnemyArray.Length -1)].SetActive(true);

        maxHealth = health;
        UpdateHealthBar();

        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isDead)
        {
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            else isPatroling = false;

            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            else isChasePlayer = false;

            if (playerInAttackRange && playerInSightRange) AttackPlayer();
            else isShoting = false;
        }
        
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
        if (muerto == false){
        isChasePlayer = true;
        agent.speed = 8f;
        agent.SetDestination(player.transform.position);
        transform.LookAt(player.transform);
    }
    }

    private void AttackPlayer()
    {
        
        agent.speed = 4f;
        //Make sure enemy doesn't move
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y -1f, player.transform.position.z));

        if (!alreadyAttacked)
        {
            ///Attack code here
            GameObject rb = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            isShoting = true;
            rb.GetComponent<Rigidbody>().AddForce(transform.forward *  Random.Range(30.0f ,35.0f ), ForceMode.Impulse);
            rb.GetComponent<Rigidbody>().AddForce(transform.up *  Random.Range(3.0f ,5.0f ), ForceMode.Impulse);
            rb.GetComponent<BulletScript>().damageBullet = damage;
            ///End of attack code

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
        isTakingDamage = true;
        health -= amount;
        UpdateHealthBar();
        //Debug.Log("estoy recibiendo daño");
        if(health <= 0f && !isDead)
        {
            muerto=true;
            agent.speed = 0f;
            Die();
        }
        
        isTakingDamage = false;
    }

    void Die()
    {
        GetComponent<Collider>().enabled = false;
        UpdateHealthBar();
        isDead = true;
        player.gameObject.GetComponent<PlayerController>().kills += 1;
        GameManager.DropLoot(transform);
        Destroy(gameObject, 3.5f);
    }

    public void UpdateHealthBar()
    {
        healSlider.maxValue = maxHealth;
        healSlider.value = health;
    }

}
