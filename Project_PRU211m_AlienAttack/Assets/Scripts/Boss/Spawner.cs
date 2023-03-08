using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private GameObject testGO;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    private float spawnTimer;
    private int enemiesSpawned;

    private ObjectPooler pooler;

    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent <ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = delayBtwSpawns;
            if (enemiesSpawned < enemyCount)
            {
                enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject newInstance = pooler.GetInstanceFromPool();
        newInstance.SetActive(true);
    }
}
