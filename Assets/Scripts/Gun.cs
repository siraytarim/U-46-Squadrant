using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public static Gun Instance; 
    private float nextTimetoFire = 0f;
    public GameObject muzzle;
    [SerializeField] float range;
    public VisualEffect muzzleEffect;
    [SerializeField] private float damage;
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
        if(Input.GetMouseButton(0))
            Shoot();
    }

    public void Shoot()
    {
        muzzleEffect.Play();
        //Debug.Log("shooting");
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag(("Enemy")))
            {
                Debug.Log("vurdu");
                GetDamage.Instance.TakeDamage(damage);
            }
        }
        
    }
}
