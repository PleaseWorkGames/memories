using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;

    private Rigidbody2D rb;

    private bool walking;
    private int orientation;

    public float speed;

    private bool inputInterrupt;

    public UserInput input;

    // Direction constants
    private const int _NORTH = 2;
    private const int _SOUTH = 0;
    private const int _WEST = 1;
    private const int _EAST = 3;

    // Use this for initialization
    void Start() {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();

        walking = false;
        inputInterrupt = false;
        orientation = _SOUTH;
    }

    // Update is called once per frame
    void Update() {
        Vector2 movementVector = input.GetMovementVector(rb.position);

        var vertical = movementVector.x;
        var horizontal = movementVector.y;

        if (vertical != 0 || horizontal != 0)
        {
            if (inputInterrupt)
            {
                stopMovement();
            }
            else
            {
                walking = true;
            }
        }
        else
        {
            stopMovement();
            inputInterrupt = false;
        }

        if (!inputInterrupt)
        {

            if (vertical > 0)
            {
                orientation = _NORTH;
            }
            else if (vertical < 0)
            {
                orientation = _SOUTH;
            }
            else if (horizontal > 0)
            {
                orientation = _EAST;
            }
            else if (horizontal < 0)
            {
                orientation = _WEST;
            }
        }

        animator.SetBool("walking", walking);
        animator.SetInteger("direction", orientation);
    }

    private void FixedUpdate()
    {
        Vector2 movementVector = input.GetMovementVector(rb.position);

        var vertical = movementVector.x;
        var horizontal = movementVector.y;

        if (!inputInterrupt)
        {
            Vector2 movement = new Vector2(horizontal, vertical);
            rb.AddForce(movement * speed);
        }
    }

    public void interruptInput()
    {
        inputInterrupt = true;
    }

    public void stopMovement()
    {
        input.SetManualMovement(true);
        walking = false;
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        input.SetManualMovement(true);
    }
}
