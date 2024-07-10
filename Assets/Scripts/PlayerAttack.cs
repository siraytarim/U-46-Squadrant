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
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        ResetAttack();
    }
    void ResetAttack()
    {
        hasShoot = true;
        Invoke("ShootAtEnemy",2f);
    } 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}

