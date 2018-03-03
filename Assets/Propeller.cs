using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    const float FAN_SPEED = 720;
    private void Update()
    {
        transform.Rotate(Vector3.forward, FAN_SPEED * Time.deltaTime);
    }
}
