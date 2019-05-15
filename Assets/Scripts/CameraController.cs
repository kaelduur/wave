using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float yOffset = 10f;
    float smoothTime = 0.15f;
    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPos = player.transform.TransformPoint(new Vector3(0, yOffset, -10));
        targetPos = new Vector3(0, targetPos.y, targetPos.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
