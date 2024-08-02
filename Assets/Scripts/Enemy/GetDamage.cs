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

<<<<<<< Updated upstream
    private void Start()
    {
        enemyCount = PlayerAttack.Instance.Enemies.Count;
    }

    public void getDamage(float hasar)
=======
    public void TakeDamage(float hasar)
>>>>>>> Stashed changes
    {
        if (gameObject != null)
        {
<<<<<<< Updated upstream
            enemyHealt -= hasar;
            Debug.Log(enemyHealt);
            if (enemyHealt <= 0)
            {
                PlayerAttack.Instance.Enemies.Remove(gameObject);
                Destroy(gameObject);
                enemyCount--;

                Debug.Log("çıkartıldı");
            }
=======
            Destroy(gameObject);
            PlayerAttack.Instance.Enemies.Remove(gameObject);
>>>>>>> Stashed changes
        }
    }
}
