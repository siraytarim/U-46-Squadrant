using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target; // Player
    private Rigidbody rigidibody;
    private Animator animator;
    private Vector3 direction;
    public float speed = 5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidibody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        direction = (target.position - transform.position).normalized;
        Vector3 velocity = direction * speed;
        rigidibody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", direction.y);
        animator.SetFloat("Vertical", direction.x);
    }
}