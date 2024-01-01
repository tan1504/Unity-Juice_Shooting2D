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
    public float scalingSpeed = 0.5f;
    public float finalScale = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            GameObject gameObject = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBtwSpawn);
            Destroy(gameObject, 5.0f);
        }
    }
}
