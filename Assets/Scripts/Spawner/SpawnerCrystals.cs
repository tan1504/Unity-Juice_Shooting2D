using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCrystals : MonoBehaviour
{
    public GameObject crystalPrefab;
    private GameObject[] crystals;
    [SerializeField] private int count = 0;
    [SerializeField] private int maxCrystals = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnerCrystal", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        crystals = GameObject.FindGameObjectsWithTag("Crystal");
        count = crystals.Length;
    }

    void SpawnerCrystal()
    {
        if (count >= maxCrystals)
        {
            // Stop Instantiate
            return;
        }
        else
        {
            Vector3 spawnPos = new Vector3(Random.Range(-15, 16), Random.Range(-15, 16), 0);
            Instantiate(crystalPrefab, spawnPos, crystalPrefab.transform.rotation);
            count++;
        }        
    }
}
