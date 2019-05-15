using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    public Vector3 maxScale;
    public float speed = 2f;
    public float duration = 5f;
    public bool repeat;

    Vector3 minScale;

    IEnumerator Start()
    {
        minScale = transform.localScale;
        while(repeat)
        {
            yield return RepeatResize(minScale, maxScale, duration);
            yield return RepeatResize(maxScale, minScale, duration);
        }
    }

    public IEnumerator RepeatResize(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
