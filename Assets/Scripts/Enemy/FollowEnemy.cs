using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float minDistance;
    private PlayerHealth playerHealth;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health >= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, this.target.position, speed * Time.deltaTime);               
        }
    }
}
