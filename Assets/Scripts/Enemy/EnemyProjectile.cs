using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 rotateChange;
    Vector3 targetPosition;
    public float speed;
    public float damage;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateChange);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            GameObject particle = Instantiate(explosion, this.transform.position, Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
