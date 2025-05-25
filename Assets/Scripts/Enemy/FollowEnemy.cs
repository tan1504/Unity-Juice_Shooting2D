using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
	public float speed;
	public float minDistance;

	void Update()
	{
		if (!GameManager.Instance.IsPlayerAlive())
			return;

		Transform target = GameManager.Instance.playerTransform;
		if (target != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}
}
