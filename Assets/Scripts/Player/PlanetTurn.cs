using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTurn : MonoBehaviour
{
    public static PlanetTurn Instance;
    [SerializeField] private float rotationSpeed;
    private Vector3 rotationDirection;

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
        if (rotationDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    
    public void SetRotationDirection(Vector3 direction)
    {
        rotationDirection = direction.normalized;
    }
}
