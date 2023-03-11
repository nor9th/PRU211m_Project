using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : MonoBehaviour
{
    public float MoveSpeed;
    private WalkPoint walkPoint;

    private int walkPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        walkPoint = GameObject.FindGameObjectsWithTag("walkpoint").GetComponent<WalkPoint>();
        //GetComponent<WalkPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, walkPoint.walkpoints[walkPointIndex].position, MoveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, walkPoint.walkpoints[walkPointIndex].position) < 0.1f)
        {
            walkPointIndex++;
        }
    }
}
