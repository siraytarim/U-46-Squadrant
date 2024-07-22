using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance; 
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;
    public Image[] hearts;

    private int currentHealth;
    private int maxHealth = 6;
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
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void GetDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
    }

        /*   public void Heal(int amount)
           {
               currentHealth += amount;
               currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
               UpdateHearts();
           }*/

    void UpdateHearts()
    { 
        for (int i = 0; i < hearts.Length; i++) 
        { 
            if (i * 2 + 1 < currentHealth)
            {
                hearts[i].sprite = heartFull;
            }
            else if (i * 2 < currentHealth)
            {
                hearts[i].sprite = heartHalf;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
        }
    }
}
