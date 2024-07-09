using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    [SerializeField] Transform planet;
    [SerializeField] float moveSpeed; // karakter hızı
    [SerializeField] float rotationSpeed; // 
    [SerializeField] float turnSpeed;
    [SerializeField] float planetRotationSpeed;
    private Vector3 lastPosition;
    private Rigidbody rb;
    public float autoMoveSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void FixedUpdate()
    {
       // rb.AddForce(transform.forward * autoMoveSpeed, ForceMode.Acceleration);

       
        Vector3 gravityDirection = (transform.position - planet.position).normalized;
        Vector3 localUp = transform.up;

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityDirection) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        rb.AddForce(gravityDirection * -9.81f);
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Quaternion turnRotation = Quaternion.Euler(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        Vector3 moveDirection = transform.forward * vertical * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        if (vertical != 0)
        {
            Vector3 planetRotationAxis = Vector3.Cross(gravityDirection, transform.forward).normalized;
            float planetRotationAngle = vertical * planetRotationSpeed * Time.deltaTime;
            planet.Rotate(planetRotationAxis, -planetRotationAngle, Space.World);
        }
    }
}