using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	public Vector3 rotateChange;
	private Vector3 targetPosition;
	public float speed;
	public float damage;
	public GameObject explosion;

	void Start()
	{
		if (GameManager.Instance.playerTransform != null)
		{
			targetPosition = GameManager.Instance.playerTransform.position;
		}
	}

	void Update()
	{
		transform.Rotate(rotateChange);
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
		{
			GameObject particle = Instantiate(explosion, transform.position, Quaternion.identity);
			particle.GetComponent<ParticleSystem>().Play();
			Destroy(particle, 3f);
			Destroy(gameObject);
		}
	}
}
