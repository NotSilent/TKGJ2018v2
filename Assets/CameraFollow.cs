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
        get { return goToFollow ? goToFollow.transform.position : transform.position + defaultOffset; }
    }

    Vector3 defaultOffset;

    bool isShaking;
    IEnumerator Shake(float time)
    {
        isShaking = true;
        yield return new WaitForSeconds(time);
        isShaking = false;
    }

    IEnumerator shaking;
    float force;
    public void StartShaking(float force)
    {
        this.force = force;
        StopAllCoroutines();
        StartCoroutine(Shake(1f));
    }

    private void Start()
    {
        defaultOffset = transform.position - goPosition;
    }

    private void LateUpdate()
    {
        EasyFollow();
        if (isShaking)
        {
            Vector2 rand = Random.insideUnitCircle * force;
            transform.localPosition += new Vector3(rand.x, rand.y, 0f);
        }
    }

    private void EasyFollow()
    {
        transform.position = goPosition + defaultOffset;
    }
}
