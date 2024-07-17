using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class GetDamage : MonoBehaviour
{
    public static GetDamage Instance;
    [SerializeField] float enemyHealt;

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

    public void TakeDamage(float hasar)
    {
        enemyHealt -= hasar;
        Debug.Log(enemyHealt);
        if (enemyHealt <= 0)
        {
            Destroy(gameObject);
            PlayerAttack.Instance.Enemies.Remove(gameObject);
        }
    }
}
