using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private Text healthText;
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Projectile": // Enemy's bullet
                health = health - collision.gameObject.GetComponent<EnemyProjectile>().damage;
                healthText.text = health + "";

                GameObject particle = Instantiate(explosion, this.transform.position, Quaternion.identity);
                particle.GetComponent<ParticleSystem>().Play();

                Destroy(collision.gameObject);

                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Player and Enemy are not IsTrigger
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                health--;
                healthText.text = health + "";

                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
