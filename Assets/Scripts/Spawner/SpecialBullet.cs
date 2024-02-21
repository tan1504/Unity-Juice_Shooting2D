using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public GameObject prefabBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                int index = Random.Range(0, 361);
                list.Add(index);
            }

            foreach (var item in list)
            {
                Instantiate(prefabBullet, transform.position, Quaternion.Euler(0, 0, item));
            }

            Destroy(gameObject);
        }
    }
}
