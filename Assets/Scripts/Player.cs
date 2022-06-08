using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

  [SerializeField] private float speed = 8f;
  [SerializeField] private float jumpForce = 800f;
  private Animator animator;
  private Rigidbody2D rigidBody2D;
  private bool isJumping = false;

  private void Start()
  {
    animator = GetComponent<Animator>();
    rigidBody2D = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    HandleMovement();
    HandleRotation();
    HandleJump();
    HandleAttack();
  }

  private void HandleMovement()
  {
    float horizontal = Input.GetAxis(KeyAxisHorizontal);
    float amountToMove = horizontal * speed * Time.deltaTime;

    transform.position += Vector3.right * amountToMove;
    animator.SetFloat(Constants.KeyAnimatorSpeed, Mathf.Abs(amountToMove));
  }

  private void HandleRotation()
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

  private void HandleJump()
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

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == TagFloor)
    {
      isJumping = false;
    }
  }
}
