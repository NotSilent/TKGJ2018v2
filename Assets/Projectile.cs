using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 direction;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DestroyAfter(5f));
    }

    public void Init(Vector3 direction, Collider collider = null)
    {
        this.direction = direction;
        rb.angularVelocity = UnityEngine.Random.insideUnitSphere * 5f;

        if (collider)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collider);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Health>()?.DealDamage(1);
    }
}
