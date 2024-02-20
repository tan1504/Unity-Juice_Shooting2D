using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 360; i=i+40)
            {
                Instantiate(prefabBullet, transform.position, Quaternion.Euler(0, 0, i));
            }
        }
    }
}
