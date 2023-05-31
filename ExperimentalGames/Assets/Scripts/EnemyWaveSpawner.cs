using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public Transform[] waypoints;

    public GameObject enemyPrefab; // the enemy prefab to spawn
    public float minSpawnInterval = 8f; // the minimum interval between spawning enemies
    public float maxSpawnInterval = 17f; // the maximum interval between spawning enemies
    public int waveSize = 10; // the number of enemies in each wave

    public int waveIncrease = 0;

    private int enemiesSpawned = 0; // the number of enemies that have been spawned in the current wave
    private bool waveInProgress = false; // whether a wave is currently in progress

    private int spawnedEnemyCount = 0;

    private void Start()
    {
        // start the first wave
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        waveInProgress = true;
        enemiesSpawned = 0;
        waveSize += waveIncrease;
        spawnedEnemyCount = 0;

        yield return new WaitForSeconds(4f);

        while (enemiesSpawned < waveSize)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            // spawn a new enemy
            GameObject newEnemy = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);
            EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.SetPath(waypoints, 0);
            }

            enemiesSpawned++;
            spawnedEnemyCount++;

            yield return new WaitForSeconds(spawnInterval);
        }

        waveInProgress = false;
    }

    private void Update()
    {
        // check if the wave is finished
        if (!waveInProgress && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Spawned " + spawnedEnemyCount + " Enemies");
            // start the next wave
            StartCoroutine(SpawnWave());
        }
    }
}
