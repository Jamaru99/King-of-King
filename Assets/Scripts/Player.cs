using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants;

public class Player : MonoBehaviour
{

  [SerializeField] private float speed = 8f;
  [SerializeField] private float jumpForce = 800f;
  private Animator animator;
  private Rigidbody2D rigidBody2D;
  private bool isJumping = false;

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
    HandleAttack();
  }

  void HandleMovement()
  {
    float horizontal = Input.GetAxis(KeyAxisHorizontal);
    float amountToMove = horizontal * speed * Time.deltaTime;

    transform.position += Vector3.right * amountToMove;
    animator.SetFloat(Constants.KeyAnimatorSpeed, Mathf.Abs(amountToMove));
  }

  void HandleRotation()
  {
    Quaternion leftDirection = new Quaternion(0, 180, 0, 0);
    Quaternion rightDirection = new Quaternion(0, 0, 0, 0);

    bool inputLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    bool inputRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

    if (inputLeft)
    {
      transform.rotation = leftDirection;
    }

    if (inputRight)
    {
      transform.rotation = rightDirection;
    }
  }

  void HandleJump()
  {
    bool input = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

    if (input && !isJumping)
    {
      isJumping = true;
      rigidBody2D.AddForce(Vector2.up * jumpForce);
    }
  }

  void HandleAttack()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      animator.SetTrigger(Constants.KeyAnimatorPlayerAttack);
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == TagFloor)
    {
      isJumping = false;
    }
  }
}
