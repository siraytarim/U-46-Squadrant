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
    public int enemyCount;

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
        enemyCount = PlayerAttack.Instance.Enemies.Count;
    }

    public void TakeDamage(float hasar)
    {
        enemyHealt -= hasar;
        Debug.Log(enemyHealt);
        if (enemyHealt <= 0)
        {
            Destroy(gameObject);
            enemyCount--;
            PlayerAttack.Instance.Enemies.Remove(gameObject);
            Debug.Log("çıkartıldı");
        }

    }
}
