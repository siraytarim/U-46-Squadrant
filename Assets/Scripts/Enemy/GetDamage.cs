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

    public void getDamage(float hasar)
    {
        if (gameObject != null)
        {
            enemyHealt -= hasar;
            Debug.Log(enemyHealt);
            if (enemyHealt <= 0)
            {
                PlayerAttack.Instance.Enemies.Remove(gameObject);
                Destroy(gameObject);
                enemyCount--;

                Debug.Log("çıkartıldı");
            }
        }

    }
}
