using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCrystals : MonoBehaviour
{
    public GameObject monstarPrefab;
    private GameObject[] monstars;
    [SerializeField] private int count = 0;
    [SerializeField] private int maxMonstar = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnerMonstar", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        monstars = GameObject.FindGameObjectsWithTag("Monstar");
        count = monstars.Length;
    }

    void SpawnerMonstar()
    {
        if (count >= maxMonstar)
        {
            // Stop Instantiate
            return;
        }
        else
        {
            Vector3 spawnPos = new Vector3(Random.Range(-15, 16), Random.Range(-15, 16), 0);
            Instantiate(monstarPrefab, spawnPos, monstarPrefab.transform.rotation);
            count++;
        }        
    }
}
