using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;
    public GameObject explosion;
    public float score;
    public bool isGameOver = false;

    private void Update()
    {
        scoreText.text = score + "";
    }

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
                Destroy(particle, 3.0f);

                if (health <= 0)
                {
                    gameObject.SetActive(false);
                    isGameOver = true;
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
                    gameObject.SetActive(false);
                    isGameOver = true;
                }
                break;
        }
    }
}
