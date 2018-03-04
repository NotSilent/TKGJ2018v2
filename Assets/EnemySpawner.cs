using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyGO;

    [SerializeField]
    GameObject explosion;

    [SerializeField]
    float timeBetweenSpawns;

    float currentTimeBetweenSpawns;

    int maxEnemyCount;
    int currentEnemyCount;
    int enemiesToNextLevel;
    int currentLevelEnemiesDead;

    public int score;

    bool CanSpawnMoreEnemies
    {
        get { return currentEnemyCount < maxEnemyCount; }
    }

    private void Awake()
    {
        currentTimeBetweenSpawns = timeBetweenSpawns;
        enemiesToNextLevel = maxEnemyCount = 3;
        currentEnemyCount = 0;
        currentLevelEnemiesDead = 0;
    }

    private void Update()
    {
        currentTimeBetweenSpawns += Time.deltaTime;
        if (currentTimeBetweenSpawns > timeBetweenSpawns && CanSpawnMoreEnemies)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemySpawnedGO = Instantiate(enemyGO, transform.position
            + Vector3.forward * Random.Range(-1, 2) * 15f +
            Vector3.right * 60f * ((Random.Range(0f, 1f) > 0.5f) ? 1f : -1f),
            Quaternion.identity, transform);
        enemySpawnedGO.transform.Rotate(Vector3.up, 180);
        enemySpawnedGO.GetComponent<Health>().onDied += (Vector3 position) => OnEnemyDied(position);
        currentEnemyCount++;
    }

    void OnEnemyDied(Vector3 position)
    {
        currentEnemyCount--;
        currentLevelEnemiesDead++;
        if (currentLevelEnemiesDead >= enemiesToNextLevel)
        {
            enemiesToNextLevel = maxEnemyCount++;
            currentLevelEnemiesDead = 0;
        }
        score++;
        Instantiate(explosion, position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
    }
}
