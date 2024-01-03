using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;

    public GameObject projectile;
    public float timeBtwShots;
    private float nextShotTime;
    public Transform firePoint; // The fire point of Enemy

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
            nextShotTime = Time.time + timeBtwShots;
        }

        if (Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, this.target.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) >= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, this.target.position, speed * Time.deltaTime);
        }
    }
}
