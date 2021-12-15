using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleWeapon : MonoBehaviour
{
    public PauseMenu PauseMenu;
    public Animator AnimationWeapon;

    public float attackRange = 2;
    public float damage = 5;
    public float AtackRate = 30f;
    public float timeAnimation;

    private float nextTimeToAtack = 0f;

    void Update() {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToAtack && !(PauseMenu._isGamePaused))
        {
            nextTimeToAtack = Time.time + 1f/AtackRate;
            AnimationWeapon.Play("Animacion cuchillo 0");
            Attack();
            
        }
    }

    public void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange* 2f))
        {
            ShooterEnemy target = hit.transform.GetComponent<ShooterEnemy>();
            ShooterBoss targetBoss = hit.transform.GetComponent<ShooterBoss>();
            MeleEnemy targetMelee = hit.transform.GetComponent<MeleEnemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            else if( targetBoss != null)
            {
                targetBoss.TakeDamage(damage);
            }
            else if( targetMelee != null)
            {
                targetMelee.TakeDamage(damage);
            }
        }
    }
}
