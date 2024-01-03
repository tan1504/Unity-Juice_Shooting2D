using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefabs;
    public Transform spawnPos;
    public float timeBtwSpawn = 1.0f;
    //public float scalingSpeed = 0.1f;
    //public float finalScale = 1.0f;
    Vector3 temp;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject gameObject = Instantiate(prefab, spawnPos.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBtwSpawn);
            //Destroy(gameObject, 5.0f);
        }
    }
}
