using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Figther))]
public class AIController : MonoBehaviour
{
    Figther figther;
    float attackSpeed = 2f;
    float lastAttackTime = Mathf.Infinity;
    void Awake()
    {
        figther = GetComponent<Figther>();
    }

    void Update()
    {
        if (lastAttackTime > attackSpeed)
        {
            HandleAttack();
            lastAttackTime = 0;
        }

        lastAttackTime += Time.deltaTime;
    }

    void HandleAttack()
    {
        // Qualquer lógica para atacar por enquanto só vou testar os tiros

        figther.Attack();
    }
}
