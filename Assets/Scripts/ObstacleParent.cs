using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(CalculateDistanceToPlayer());
    }

    IEnumerator CalculateDistanceToPlayer()
    {
        while(true)
        {
            if(player.transform.position.y - transform.position.y > 50)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
