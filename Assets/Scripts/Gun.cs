using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun Instance; 
    private float nextTimetoFire = 0f;
    public GameObject muzzle;
    public float range = 100f;
    public ParticleSystem muzzleEffect;
    private GameObject Enemy;
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
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Shoot()
    {
        muzzleEffect.Play();
        Debug.Log("shooting");
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag(("Enemy")))
            {
                Destroy(Enemy);
            }
        }
        
    }
}
