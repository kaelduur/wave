using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool upDown = false;
    public float delta;
    public float speed;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        if(!upDown)
        {
            Vector3 newPos = startPos;
            newPos.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        }
        else if(upDown)
        {
            Vector3 newPos = startPos;
            newPos.y += delta * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);
        }
    }
}
