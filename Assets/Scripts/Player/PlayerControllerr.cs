using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    [Header("Player")] [SerializeField] private CharacterController controller;
    [SerializeField] private Transform planet;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float verticalSpeed;
    Rigidbody rb;
    public float gravity = -9.81f;
    private float velocity;
    private Vector3 direction;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        velocity += gravity * 10 * Time.deltaTime;
        direction.y = velocity;
        //karalter hareketi

        // Karakterin hareket yönünü belirle
        Vector3 moveDirection = transform.forward * verticalSpeed;
        controller.Move( moveDirection * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
           // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}