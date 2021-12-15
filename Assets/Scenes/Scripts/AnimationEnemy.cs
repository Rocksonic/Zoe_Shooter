using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    public GameObject ShooterEnemy;
    
    Animator[] EnemyA;
public bool parador;
    void Start()
    {
        EnemyA = GetComponents<Animator>();
        EnemyA[0].SetBool("caminando", false);
        EnemyA[0].SetBool("correrE", false);
        EnemyA[0].SetBool("disparandoEnemigo", false);
        EnemyA[0].SetBool("muerto", false);
        EnemyA[0].SetBool("golpeado", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            EnemyA[0].SetBool("parado", true);
            EnemyA[0].SetBool("caminando", false);
            parador=false;
        }
        else
        {
            EnemyA[0].SetBool("parado", false);
            parador=true;
        }
        
        if (ShooterEnemy.GetComponent<ShooterEnemy>().isPatroling)
        {
            EnemyA[0].SetBool("caminando", true);
            EnemyA[0].SetBool("muerto", false);
        }
        else if (ShooterEnemy.GetComponent<ShooterEnemy>().isChasePlayer)
        {
            EnemyA[0].SetBool("muerto", false);
            EnemyA[0].SetBool("parado", false);
            EnemyA[0].SetBool("disparandoEnemigo", false);
            EnemyA[0].SetBool("correrE", true);
        }
        else if ( ShooterEnemy.GetComponent<ShooterEnemy>().isShoting)
        {
            EnemyA[0].SetBool("caminando", false);
            EnemyA[0].SetBool("correrE", false);
            EnemyA[0].SetBool("disparandoEnemigo", true);
            EnemyA[0].SetBool("muerto", false);
        }

        if (ShooterEnemy.GetComponent<ShooterEnemy>().isTakingDamage)
        {
            EnemyA[0].SetBool("golpeado", true);
            ShooterEnemy.GetComponent<ShooterEnemy>().isTakingDamage = false;
            EnemyA[0].SetBool("muerto", false);
            
        }
        else if (ShooterEnemy.GetComponent<ShooterEnemy>().isDead)
        {
            EnemyA[0].SetBool("muerto", true);
        }
        else
        {
            EnemyA[0].SetBool("golpeado", false);
            EnemyA[0].SetBool("muerto", false);
        }
    }
}
