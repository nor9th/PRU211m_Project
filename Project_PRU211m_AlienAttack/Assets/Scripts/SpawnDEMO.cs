using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class SpawnDEMO : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float counter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;

        if (counter > 1)
        {
            for (int i = 0; i < 5; i++)
            {
                
                GameObject obj = Instantiate<GameObject>(enemy, transform.position, Quaternion.identity);
                

            }

            counter = 0;
        }
    }
}
