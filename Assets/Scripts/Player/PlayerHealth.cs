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
	public bool isDead = false;

	private void Start()
	{
		// Gán tham chiếu vào GameManager
		GameManager.Instance.playerHealth = this;
		GameManager.Instance.playerTransform = transform;
	}

	private void Update()
	{
		scoreText.text = score.ToString("0");
	}

	private void Die()
	{
		if (isDead) return;

		isDead = true;
		health = 0;
		healthText.text = "0";

		GameObject particle = Instantiate(explosion, transform.position, Quaternion.identity);
		particle.GetComponent<ParticleSystem>().Play();
		Destroy(particle, 3f);

		GetComponent<Collider2D>().enabled = false;
		if (TryGetComponent<Rigidbody2D>(out var rb))
			rb.simulated = false;

		GameManager.Instance.TriggerGameOver();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isDead) return;

		if (collision.CompareTag("Projectile"))
		{
			float damage = collision.GetComponent<EnemyProjectile>().damage;
			health -= damage;
			healthText.text = health.ToString("0");

			GameObject particle = Instantiate(explosion, transform.position, Quaternion.identity);
			particle.GetComponent<ParticleSystem>().Play();
			Destroy(particle, 3f);
			Destroy(collision.gameObject);

			if (health <= 0)
				Die();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isDead) return;

		if (collision.gameObject.CompareTag("Enemy"))
		{
			health--;
			healthText.text = health.ToString("0");

			if (health <= 0)
				Die();
		}
	}
}
