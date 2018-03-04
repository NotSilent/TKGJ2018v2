using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Train : Vehicle
{
    private void Update()
    {
        CurrentCooldown += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && CurrentCooldown > CurrentWeapon.Cooldown)
        {
            CurrentWeapon.SpawnBullets(GunPosition, transform.forward, GetComponent<Collider>());
            CurrentCooldown = 0f;
        }
    }

    private void Start()
    {
        GetComponent<Health>().onDied += (position) =>
        {
            PlayerPrefs.SetString("score", GetComponentInChildren<EnemySpawner>().score.ToString());
            SceneManager.LoadScene("End");
        };
        GetComponent<Health>().onDamageTaken += () => ScreenShake();
    }

    protected override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Velocity = horizontal * Speed;
    }

    void ScreenShake()
    {
        FindObjectOfType<CameraFollow>().StartShaking(0.5f, 5f);
    }
}
