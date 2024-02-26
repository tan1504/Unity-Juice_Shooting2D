using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Vector3 rotateChange;
    public GameObject explosionEnemy;
    public GameObject explosionMonStar;

    void Update()
    {
        transform.Rotate(rotateChange);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject particle = Instantiate(explosionEnemy, this.transform.position, Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
            Destroy(particle, 3.0f);
        }

        if (collision.CompareTag("Monstar"))
        {
            GameObject particle = Instantiate(explosionMonStar, this.transform.position, Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
            Destroy(particle, 3.0f);
        }
    }
}
