using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Keys;

public class Player : MonoBehaviour
{
  private Animator animator;
  private Rigidbody2D rigidBody2D;

  private float speed = 5f;
  private float jumpForce = 400f;

  void Start()
  {
    animator = GetComponent<Animator>();
    rigidBody2D = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    HandleMovement();
    HandleRotation();
    HandleJump();
  }

  void HandleMovement()
  {
    float horizontal = Input.GetAxis(KeyAxisHorizontal);
    bool isWalking = horizontal != 0;
    float amtToMove = horizontal * speed * Time.deltaTime;

    transform.position += Vector3.right * amtToMove;

    animator.SetBool(KeyAnimatorIsWalking, isWalking);
  }

  void HandleRotation()
  {
    Quaternion leftDirection = new Quaternion(0, 180, 0, 0);
    Quaternion rightDirection = new Quaternion(0, 0, 0, 0);

    if (Input.GetKey(KeyCode.LeftArrow))
    {
      transform.rotation = leftDirection;
    }

    if (Input.GetKey(KeyCode.RightArrow))
    {
      transform.rotation = rightDirection;
    }
  }

  void HandleJump()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      rigidBody2D.AddForce(Vector2.up * jumpForce);
    }
  }
}
