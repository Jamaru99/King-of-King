using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants;

public class Banana : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    private float fallSpeed = 30f;
    private float respawnPositionY = 60f;

    private void Start()
    {
      rigidBody2D = GetComponent<Rigidbody2D>();
      rigidBody2D.velocity = Vector3.down * fallSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == TagDeadline)
      {
        RespawnBanana();
      }
    }

    private void RespawnBanana()
    {
      rigidBody2D.velocity = Vector3.down * fallSpeed;
      Vector2 respawnPosition = new Vector2(transform.position.x, respawnPositionY);
      transform.position = respawnPosition;
    }
}
