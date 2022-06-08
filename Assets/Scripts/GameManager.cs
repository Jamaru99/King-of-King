using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } set { instance = value; } }

    private void Awake()
    {
        instance = this;
    }
}
