using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public static Gun Instance; 
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
    public void Shoot()
    {
<<<<<<< Updated upstream
        Debug.Log("saldırıldı");
        muzzleEffect.Play();
        Vector3 direction = (PlayerAttack.nearestOBJ.transform.position - muzzle.transform.position).normalized;
       // muzzleEffect.transform.position += direction * 10 * Time.deltaTime;
       muzzleEffect.transform.position = muzzle.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, direction, out hit, range))
=======
      //  muzzleEffect.Play();

        StartCoroutine(MoveEfect(PlayerAttack.nearestOBJ.transform));

        //Debug.Log("shooting");
      
    }
    
    IEnumerator  MoveEfect(Transform target)
    {
        while (true)
>>>>>>> Stashed changes
        {
            if (target == null)
            {
<<<<<<< Updated upstream
                Debug.Log("vurdu");
                hit.collider.GetComponent<GetDamage>().getDamage(damage);
                VisualEffect Muzzle = Instantiate(muzzleEffect, hit.point, Quaternion.LookRotation(direction));
                  Destroy(Muzzle.gameObject, 2f);
                Debug.DrawLine(muzzle.transform.position, hit.transform.position + direction * range, Color.green, 2f);
=======
                yield break; 
>>>>>>> Stashed changes
            }

            Vector3 direction = (PlayerAttack.nearestOBJ.transform.position - muzzleEffect.transform.position).normalized;
            muzzle.transform.position += direction * 20 * Time.deltaTime;
            RaycastHit hit;
            if (Physics.Raycast(muzzleEffect.transform.position, direction, out hit, range))
            {
                if (hit.collider.CompareTag(("Enemy")))
                {
                    Debug.Log("vurdu");
                    GetDamage.Instance.TakeDamage(damage);
                    Debug.DrawLine(muzzle.transform.position, muzzle.transform.position + direction * range, Color.green, 2f);
                    yield break;
                }
            }
            yield return null;
        }

    }
}
