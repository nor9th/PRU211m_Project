using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;
    private int waveIndex = 0;

    public static int EnemiesAlive = 0;

    //[SerializeField] private float spawnRate = 1f;
    //[SerializeField] private GameObject[] bossPrefabs;
    //[SerializeField] private bool canSpawn = true;

    // Start is called before the first frame update
    private void Start()
    {
        //StartCoroutine(BossSpawner());
        //StartCoroutine(SpawnWave());
    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        /*if (waveIndex == waves.Length)
        {
            //gameManager.WinLevel();
            this.enabled = false;
        }*/

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    /*private IEnumerator BossSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = UnityEngine.Random.Range(0, bossPrefabs.Length);
            GameObject bossToSpawn = bossPrefabs[rand];

            Instantiate(bossToSpawn, transform.position, Quaternion.identity);
        }
    }*/


    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            int rand = UnityEngine.Random.Range(0, wave.enemy.Length);
            GameObject bossToSpawn = wave.enemy[rand];

            Instantiate(bossToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject[] enemy)
    {
        //Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
