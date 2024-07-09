using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 move; // X: Horizontal (A, D), Y: Vertical (W, S)
    private Animator animator;
    private Rigidbody rigidibody;
    private PlanetaryGravity planetaryGravity;
    [SerializeField] private float moveSpeed = 5.0f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidibody = GetComponent<Rigidbody>();
        planetaryGravity = GetComponent<PlanetaryGravity>();
    }

    void Update()
    {
        UpdateAnimator();
        EarthIsNotFlat();
    }

    void FixedUpdate()
    {
        Move();
    }

#region Movement
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }


    void Move()
    {
        //EarthIsNotFlat(); 
        CalculateMovement();
    }

    void EarthIsNotFlat()
    {
        // This updates the player's up vector (y-axis) to match the gravity direction. Run this first.
        Vector3 gravityDirection = planetaryGravity.toCenterNormalized;
        if (gravityDirection.x <= -0.9f)
        {
            transform.up = Vector3.right;
        }
        else if (gravityDirection.y <= -0.9f)
        {
            transform.up = Vector3.up;
        }
        else if (gravityDirection.z <= -0.9f)
        {
            transform.up = Vector3.forward;
        }
        else
        {
            transform.up = -gravityDirection;
        }
    }

    void CalculateMovement()
    {
        // This calculates the movement of the player based on the gravity direction. Run this second.
        Vector3 movement = new Vector3(move.x, 0, move.y) * moveSpeed * Time.fixedDeltaTime;  // y-axis for vertical movement.
        Vector3 newPosition = rigidibody.position + movement; // Calculate the new position
        rigidibody.MovePosition(newPosition); // Move the rigidbody to the new position
    }

#endregion
    void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
    }
}