using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotation = 45f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);   
    }
}
