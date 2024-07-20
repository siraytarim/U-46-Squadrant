using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance;
    [Header("Bullet")]
    public float bulletCoolDown;
    
    [Header("Enemy")]
    [SerializeField] LayerMask whatIsEnemy;
    public static bool enemyInattackRange;
    public List<GameObject> Enemies;
    float distance;
    float nearestDistance = 1000;
    public static GameObject nearestOBJ;
    
    [Header("Player")]
    public float attackRange;
    public bool hasShoot;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        hasShoot = false;
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Enemy");
        Enemies.AddRange(foundObjects);
        for (int i = 0; i < Enemies.Count; i++)
        {
            distance = Vector3.Distance(transform.position, Enemies[i].transform.position);
            if (distance < nearestDistance)
            {
                nearestOBJ = Enemies[i];
                nearestDistance = distance;
                Debug.Log(nearestOBJ.name);
            }
        }
    }

    private void Update()
    {
        if (!hasShoot)
        {
            enemyInattackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);

            if (enemyInattackRange)
            {
                Gun.Instance.Shoot();
                ResetAttack();
            }
        }
    }

   /* void ShootAtEnemy()
    {
        Gun.Instance.Shoot();
        ResetAttack();
    }*/

    void ResetAttack()
    {
        hasShoot = true;
        Invoke("AllowShooting" ,bulletCoolDown);
    }
    void AllowShooting()
    {
        if (Enemies.Count <= 0)
            hasShoot = true;
        else
        hasShoot = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}