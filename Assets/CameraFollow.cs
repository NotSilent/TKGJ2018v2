using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject goToFollow;

    [SerializeField]
    float maxAngle = 5f;

    Vector3 goPosition
    {
        get { return goToFollow? goToFollow.transform.position : transform.position + defaultOffset; }
    }

    Vector3 defaultOffset;

    private void Start()
    {
        defaultOffset = transform.position - goPosition;
    }

    private void LateUpdate()
    {
        Vector3 currentOffset = transform.position - goPosition;

        //float angle = Vector3.Angle(currentOffset, defaultOffset);

        //transform.position = Vector3.MoveTowards(currentOffset, defaultOffset, 50f);

        //transform.position = goToFollow.transform.position + defaultOffset;

        Quaternion fromToRotation = Quaternion.FromToRotation(currentOffset, defaultOffset);
        transform.position = goPosition + (fromToRotation * currentOffset);

        //Quaternion toRotation = Quaternion.LookRotation(defaultOffset);
        //Quaternion fromRotation = Quaternion.LookRotation(currentOffset);
        //float angle = Quaternion.Angle(fromRotation, toRotation);

        //Quaternion lerped = Quaternion.Lerp(fromRotation, toRotation, (angle / maxAngle) * Time.deltaTime);

        //Vector3 lerped2 = Vector3.Lerp(currentOffset, defaultOffset, (angle / maxAngle));

        //transform.position = lerped2;
    }
}
