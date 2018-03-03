using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyGO;

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
        if(currentTimeBetweenSpawns > timeBetweenSpawns && CanSpawnMoreEnemies)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 rand = Random.insideUnitSphere * 30f;
        rand.y = 0f;
        GameObject enemySpawnedGO = Instantiate(enemyGO, transform.position + rand, Quaternion.identity, transform);
        enemySpawnedGO.transform.Rotate(Vector3.up, 180);
        enemySpawnedGO.GetComponent<Health>().onDied += () => OnEnemyDied();
        currentEnemyCount++;
    }

    void OnEnemyDied()
    {
        currentEnemyCount--;
        currentLevelEnemiesDead++;
        if(currentLevelEnemiesDead >= enemiesToNextLevel)
        {
            enemiesToNextLevel = maxEnemyCount++;
            currentLevelEnemiesDead = 0;
        }
        score++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
