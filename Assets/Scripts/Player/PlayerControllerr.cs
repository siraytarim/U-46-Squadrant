using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    [Header("Player")] 
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform planet;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float verticalSpeed;
    Rigidbody rb;
    [SerializeField] float gravity ;
    private Vector3 velocity;
    private Vector3 direction;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      //  anim.SetFloat("Vertical",2f);
       // anim.SetFloat("Horizontal",2f);

        Vector3 moveDirection = transform.forward * verticalSpeed;
        
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move( (moveDirection + velocity) * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
           // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}