using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // speed of movement
    public float maxX = 5f; // maximum x position
    public float maxY = 5f; // maximum y position
    public float minX = -5f; // minimum x position
    public float minY = -5f; // minimum y position

    private Animator animator;
    public Transform target;

    private Rigidbody2D rb; // Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        // get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get input from arrow keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        //Tell animator whether we're idle or not.
        if (movement == Vector2.zero)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }

        // normalize movement vector so diagonal movement is not faster
        movement = movement.normalized;

        Vector2 targetDirection = target.position - transform.position;
        targetDirection.Normalize();

        // set the appropriate animation parameter based on the direction
        if (targetDirection.y > 0.5f)
        {
            // target is above player
            if (targetDirection.x > 0.5f)
            {
                // target is in the northeast direction
                animator.SetFloat("TargetDirection", 1f);
            }
            else if (targetDirection.x < -0.5f)
            {
                // target is in the northwest direction
                animator.SetFloat("TargetDirection", 7f);
            }
            else
            {
                // target is directly above player
                animator.SetFloat("TargetDirection", 0f);
            }
        }
        else if (targetDirection.y < -0.5f)
        {
            // target is below player
            if (targetDirection.x > 0.5f)
            {
                // target is in the southeast direction
                animator.SetFloat("TargetDirection", 3f);
            }
            else if (targetDirection.x < -0.5f)
            {
                // target is in the southwest direction
                animator.SetFloat("TargetDirection", 5f);
            }
            else
            {
                // target is directly below player
                animator.SetFloat("TargetDirection", 4f);
            }
        }
        else if (targetDirection.x > 0.5f)
        {
            // target is to the right of player
            animator.SetFloat("TargetDirection", 2f);
        }
        else if (targetDirection.x < -0.5f)
        {
            // target is to the left of player
            animator.SetFloat("TargetDirection", 6f);
        }
        //TargetIs 0n, 1ne, 2e, 3se, 4s, 5sw, 6w, 7nw


        // stablish parameters for the animations
        animator.SetFloat("DirectionX", movement.x);
        animator.SetFloat("DirectionY", movement.y);

        // apply movement to Rigidbody2D component
        rb.velocity = movement * speed;

        // clamp position within range
        Vector2 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        rb.position = clampedPosition;
        if (speed == 0)
        {
            animator.SetBool("Dead",true);
        }
        else
        {
            animator.SetBool("Dead", false);
        }
    }
}
