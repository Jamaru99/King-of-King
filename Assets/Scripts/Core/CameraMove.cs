using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants;

public class CameraMove : MonoBehaviour
{
  private Transform player;
  [SerializeField] float minX = -100f;
  [SerializeField] float maxX = 100f;
  [SerializeField] float minY = 0f;
  [SerializeField] float maxY = 100f;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag(TagPlayer).transform;
  }

  void Update()
  {
      
      float x = Mathf.Clamp(player.position.x, minX, maxX);
      float y = Mathf.Clamp(player.position.y, minY, maxY);

      transform.position = new Vector3(x, y, transform.position.z);
  }
}
