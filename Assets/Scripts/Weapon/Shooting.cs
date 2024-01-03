using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; // The reference bullet
    public Transform firePoint; // The fire point on cannon
    public float fireForce;
    public float bulletTimeLife;
    private float timer;
    public float timeBetweenFire;

    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        timer = timer - Time.deltaTime;
        if (Input.GetMouseButton(1) && timer < 0) // Pressed right-click
        {
            Fire();
        }
    }

    public void Fire()
    {
        timer = timeBetweenFire;

        GameObject instanceBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        instanceBullet.GetComponent<Rigidbody2D>().AddForce((transform.right * (-1)) * fireForce, ForceMode2D.Impulse);

        Destroy(instanceBullet, bulletTimeLife);
    }
}
