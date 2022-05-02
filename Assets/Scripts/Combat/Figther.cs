using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figther : MonoBehaviour
{
    [SerializeField] Gun gun = null;
    [SerializeField] Transform gunPipe = null;

    public void Attack()
    {
        if (gun == null || gunPipe == null) { return;}

        gun.Shoot(gunPipe);
    }

}
