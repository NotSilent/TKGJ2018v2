﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : Vehicle
{
    private void Update()
    {
        CurrentCooldown += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && CurrentCooldown > CurrentWeapon.Cooldown)
        {
            CurrentWeapon.SpawnBullet(GunPosition, transform.forward, GetComponent<Collider>());
            CurrentCooldown = 0f;
        }
    }

    protected override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Velocity = horizontal * Speed;
    }
}
