using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Vector2 movementDirection;
    public Rigidbody2D rigidBody;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0f, 1f);
        movementDirection.Normalize();
        Move();
        Animated();
        if (Input.GetAxis("Horizontal") >= 0.1f || Input.GetAxis("Horizontal") <= -0.1f || Input.GetAxis("Vertical") <= 0.1f || Input.GetAxis("Vertical") <= -0.1f)
        { animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal")); animator.SetFloat("LastMoveY", Input.GetAxis("Vertical")); }
    }
    public void Move()
    {
        rigidBody.velocity = movementDirection * movementSpeed;
    }
    public void Animated()
    {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementSpeed);
    }
}
