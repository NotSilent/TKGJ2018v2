using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "TKGJ/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    int bullets;
    [SerializeField]
    float cooldown;
    public float Cooldown
    {
        get { return cooldown; }
    }

    public void SpawnBullets(Vector3 position, Vector3 direction, Collider collider = null)
    {
        if (bullets == 1)
        {
            GameObject projectileGO = Instantiate(projectilePrefab, position, Quaternion.identity);
            projectileGO.GetComponent<Projectile>()?.Init(direction, 0f, collider);
        }
        else
        {
            float angle = (bullets - 1) * 30f;
            for (int i = 0; i < bullets; i++)
            {
                float frac = angle / (bullets - 1);
                float currAngle = frac * i - angle / 2;
                GameObject projectileGO = Instantiate(projectilePrefab, position, Quaternion.identity);
                projectileGO.GetComponent<Projectile>()?.Init(direction, currAngle, collider);
            }
        }
    }
}
