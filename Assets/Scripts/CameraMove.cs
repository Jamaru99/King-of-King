using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants;

public class CameraMove : MonoBehaviour
{
  private Transform player;

  float minX;
  float maxX;
  float minY;
  float maxY;

  void Start()
  {
    minX = -100f;
    maxX = 100f;
    minY = 0;
    maxY = 100f;

    player = GameObject.FindGameObjectWithTag(TagPlayer).transform;
  }

  void Update()
  {
    transform.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
  }
}
