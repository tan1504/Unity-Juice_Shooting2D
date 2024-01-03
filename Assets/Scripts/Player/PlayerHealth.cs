using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private Text healthText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Projectile": // Enemy's bullet
                health = health - collision.gameObject.GetComponent<EnemyProjectile>().damage;
                healthText.text = health + "";

                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
