using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane : Vehicle
{
    static Train train;
    static Train PlayerTrain
    {
        get
        {
            if (!train)
                train = FindObjectOfType<Train>();
            return train;
        }
    }

    private void Start()
    {
        GetComponent<Health>().onDamageTaken += () => ScreenShake();
    }

    private void Update()
    {
        CurrentCooldown += Time.deltaTime;
        if (CurrentCooldown > CurrentWeapon.Cooldown)
        {
            CurrentWeapon.SpawnBullet(GunPosition, transform.forward, GetComponent<Collider>());
            CurrentCooldown = 0f;
        }
    }

    protected override void Move()
    {
        float distance = Mathf.Clamp(Mathf.Abs(transform.position.x - PlayerTrain.transform.position.x), 0f, 1f);
        float horizontal = transform.position.x > PlayerTrain.transform.position.x ? distance : -distance;
        Velocity = horizontal * Speed;
    }

    void ScreenShake()
    {
        FindObjectOfType<CameraFollow>().StartShaking(1f);
    }
}
