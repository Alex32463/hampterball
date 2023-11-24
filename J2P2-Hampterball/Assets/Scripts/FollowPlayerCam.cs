using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCam : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    void Update()
    {
        Vector3 nuPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, nuPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
