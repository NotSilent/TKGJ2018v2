using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    public Action<Vector3> onDied;
    public Action onDamageTaken;

    public void DealDamage(int val)
    {
        health -= val;

        onDamageTaken?.Invoke();

        if (health <= 0)
        {
            onDied?.Invoke(transform.position);
            Destroy(gameObject);
        }
    }
}
