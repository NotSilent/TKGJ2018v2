using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    public Action onDied;

    public void DealDamage(int val)
    {
        health -= val;

        if (health <= 0)
        {
            onDied?.Invoke();
            Destroy(gameObject);
        }
    }
}
