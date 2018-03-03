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
        GetComponent<Health>().onDied += () => OnPlayerDied();
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
        float distance = Mathf.Abs(transform.position.x - PlayerTrain.transform.position.x);
        float horizontal = transform.position.x > PlayerTrain.transform.position.x ? distance : -distance;
        Velocity = horizontal * Speed;
    }

    private void OnPlayerDied()
    {
        SceneManager.LoadScene("End");
    }
}
