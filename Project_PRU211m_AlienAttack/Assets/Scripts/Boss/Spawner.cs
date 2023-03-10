using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] bossPrefabs;
    [SerializeField] private bool canSpawn = true;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(BossSpawner());
    }

    private IEnumerator BossSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = UnityEngine.Random.Range(0, bossPrefabs.Length);
            GameObject bossToSpawn = bossPrefabs[rand];

            Instantiate(bossToSpawn, transform.position, Quaternion.identity);
        }
    }
}
