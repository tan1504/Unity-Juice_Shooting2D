using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float exp;
    public GameObject explosion;
    public GameObject playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                health = health - collision.gameObject.GetComponent<Bullet>().damage;

                if (health <= 0)
                {
                    GameObject particle = Instantiate(explosion, this.transform.position, Quaternion.identity);
                    particle.GetComponent<ParticleSystem>().Play();
                    Destroy(this.gameObject);
                    Destroy(particle, 3.0f);

                    playerHealth = GameObject.FindGameObjectWithTag("Player");
                    playerHealth.GetComponent<PlayerHealth>().score += exp;
                    float scoreBonus = Random.Range(1, 20);
                    if (scoreBonus >= 1 && scoreBonus <= 6)
                    {
                        playerHealth.GetComponent<PlayerHealth>().score += scoreBonus;
                    }
                }
                break;
        }
    }
}
