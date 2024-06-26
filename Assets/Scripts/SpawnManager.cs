using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject []enemies;
    public GameObject powerUp;

    public float enemySpawn = 10f;
    public float xSpawnRange = 70f;
    public float zSpawnRange = 45f;
    public float powerUpRange = 15f;
    public float pSpawnRange = 10f;

    public float powerUpSpawnTime = 20;
    public float enemySpawnTime = 15;
    public float startDelay = 3f;


    // Start is called before the first frame update
    public void StartGame()
    {

        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, 0.5f, randomZ);
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    private void SpawnPowerUp()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, 1.5f, randomZ);

        Instantiate(powerUp, spawnPos, powerUp.gameObject.transform.rotation);

    }
}
