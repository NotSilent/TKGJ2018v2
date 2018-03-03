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

    public void SpawnBullet(Vector3 position, Vector3 direction, Collider collider = null)
    {
        GameObject projectileGO = Instantiate(projectilePrefab, position, Quaternion.identity);
        projectileGO.GetComponent<Projectile>()?.Init(direction, collider);
    }
}
