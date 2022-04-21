using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private Animator animator;

  private float speed = 5f;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void FixedUpdate()
  {
    HandleMovement();
  }

  void HandleMovement()
  {
    float horizontal = Input.GetAxis("Horizontal");
    bool isWalking = horizontal != 0;
    float amtToMove = horizontal * speed * Time.deltaTime;
    transform.Translate(Vector3.right * amtToMove);
    animator.SetBool("isWalking", isWalking);
  }
}
