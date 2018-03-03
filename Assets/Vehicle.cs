using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;
    protected Weapon CurrentWeapon
    {
        get { return weapon; }
    }

    [SerializeField]
    GameObject gunPosition;
    protected Vector3 GunPosition
    {
        get { return gunPosition.transform.position; }
    }

    [SerializeField]
    float speed = 5;
    protected float Speed
    {
        get { return speed; }
    }

    Rigidbody rb;
    protected float Velocity
    {
        set { rb.velocity = transform.right * value; }
    }
    float currentCooldown;
    protected float CurrentCooldown
    {
        get; set;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected abstract void Move();
}
