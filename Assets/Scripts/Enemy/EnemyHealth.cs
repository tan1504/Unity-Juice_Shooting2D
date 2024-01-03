using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                health = health - collision.gameObject.GetComponent<Bullet>().damage;

                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
