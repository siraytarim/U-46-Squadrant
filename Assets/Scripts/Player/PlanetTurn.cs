using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTurn : MonoBehaviour
{
    public static PlanetTurn Instance;
    [SerializeField] private float rotationSpeed;
    private Vector3 rotationDirection, moveDirection;
    public float rotationMultiplier;
    

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
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float turnSpeed = rotationSpeed + horizontal * rotationMultiplier;

        // Planeti döndür
        transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
    }
    
    public void SetRotationDirection(Vector3 direction)
    {
        rotationDirection = direction.normalized;
    }
}
