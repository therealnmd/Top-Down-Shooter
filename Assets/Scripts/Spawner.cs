using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private float timeBetweenSpawn = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawnPosition = spawnPos[Random.Range(0, spawnPos.Length)];
            Instantiate(enemy, spawnPosition.position, Quaternion.identity);
        }
    }
}
