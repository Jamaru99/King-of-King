using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hitPoints = 15f;

    public void TakeDamage(float damage)
    {
        print(damage);
        hitPoints = Mathf.Max(hitPoints - damage, 0);

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Fazer algo legal aqui quando morrer kkkj
        print("Morreu");
    }
}
