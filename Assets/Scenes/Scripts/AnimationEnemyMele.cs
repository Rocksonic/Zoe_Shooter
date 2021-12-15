using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyMele : MonoBehaviour
{
    public GameObject MeleEnemy;
    Animator[] EnemyA;

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
        if (MeleEnemy.GetComponent<MeleEnemy>().isPatroling)
        {
            EnemyA[0].SetBool("caminando", true);
        }
        else if (MeleEnemy.GetComponent<MeleEnemy>().isChasePlayer)
        {
            Debug.Log("buscando enemigo");
            EnemyA[0].SetBool("correrE", true);
        }
        else if ( MeleEnemy.GetComponent<MeleEnemy>().isHitting)
        {
            EnemyA[0].SetBool("caminando", false);
            EnemyA[0].SetBool("correrE", false);
            EnemyA[0].SetBool("golpeado", true);
        }
    }
}
