using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected override void Move()
    {
        float distance = Mathf.Abs(transform.position.x - PlayerTrain.transform.position.x);
        float horizontal = transform.position.x > PlayerTrain.transform.position.x ? distance : -distance;
        Velocity = horizontal * Speed;
    }
}
