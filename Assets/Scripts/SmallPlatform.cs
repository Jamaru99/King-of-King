using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlatform : MonoBehaviour
{
  public float minY;
  public float maxY;

  void Start()
  {
    float posX = Random.Range(-100f, 100f);
    float posY = Random.Range(minY, maxY);

    transform.position = new Vector2(posX, posY);
  }
}
