using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    public void DealDamage(int val)
    {
        health -= val;

        if (health <= 0)
            Destroy(gameObject);
    }
}
