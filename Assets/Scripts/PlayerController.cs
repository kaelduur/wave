using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject deadEffect;
    public GameObject collectibleEffect;

    public Rigidbody rb;
    public float delta = 2.3f;
    public float lrSpeed = 2.5f;
    public float upSpeed = 2.5f;
    public float maxUpSpeed = 3f;
    public bool isBoosted = false;

    Vector3 startPos;
    bool isDead = false;

    GameController gameController;
    float hueValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void Start()
    {
        hueValue = Random.Range(0, 10) / 10.0f;
        SetBackgroundColor();
    }

    void FixedUpdate()
    {
        if (isDead == true) return;


        Vector3 newPos = startPos;
        newPos.x += delta * Mathf.Sin(Time.time * lrSpeed);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);

        if(Input.GetMouseButton(0))
        {
            isBoosted = true;
            rb.AddForce(transform.up * upSpeed);
        }
        else if(!Input.GetMouseButton(0))
        {
            isBoosted = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Dead();
        }
        else if (other.gameObject.tag == "Collectible")
        {
            GetItem(other);
        }
    }

    void GetItem(Collider other)
    {
        SetBackgroundColor();

        Destroy(Instantiate(collectibleEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject);
        gameController.AddScore();
    }

    void Dead()
    {
        isDead = true;

        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 0.7f);
        StopPlayer();

        gameController.CallGameOver();
    }

    void StopPlayer()
    {
        Destroy(this.GetComponent<SphereCollider>());

        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
    }

    void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);

        hueValue += 0.1f;
        if(hueValue >= 1)
        {
            hueValue = 0;
        }
    }
}
