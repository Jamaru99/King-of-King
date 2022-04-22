using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Keys;

public class Player : MonoBehaviour
{
  private Animator animator;

  private float speed = 5f;
  private bool isFacingLeft = false;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void FixedUpdate()
  {
    HandleMovement();
    HandleRotation();
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
    if (Input.GetKey(KeyCode.LeftArrow) && !isFacingLeft)
    {
      isFacingLeft = true;
      transform.Rotate(0, 180, 0);
    }
    if (Input.GetKey(KeyCode.RightArrow) && isFacingLeft)
    {
      isFacingLeft = false;
      transform.Rotate(0, 180, 0);
    }
  }
}
