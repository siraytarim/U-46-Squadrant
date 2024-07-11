using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform bulletSpawnPoint;
    public float bulletCoolDown;
    
    [Header("Enemy")]
    [SerializeField] GameObject Enemy;
    [SerializeField] private LayerMask whatIsEnemy;
    public bool enemyInattackRange;
    
    [Header("Player")]
    public float attackRange;
    public bool hasShoot;

    private void Start()
    {
        hasShoot = false;
    }

    private void Update()
    {
        if (!hasShoot)
        {
            enemyInattackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);

            if (enemyInattackRange)
            {
                print("attack range");
                ShootAtEnemy();
            }
        }
    }

    void ShootAtEnemy()
    {
        Gun.Instance.Shoot();
        ResetAttack();
    }

    void ResetAttack()
    {
        hasShoot = true;
        Invoke("AllowShooting" ,bulletCoolDown);
    }
    void AllowShooting()
    {
        hasShoot = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}

