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
        walkPoint = GameObject.FindGameObjectWithTag("walkpoint").GetComponent<WalkPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, walkPoint.walkpoints[walkPointIndex].position, MoveSpeed * Time.deltaTime);

        Vector3 dir = walkPoint.walkpoints[walkPointIndex].position - transform.position;
        /*float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

        if (transform.position.x < dir.x)
        {
            transform.localScale = new Vector3(1, 1, 0);
            dir.x = transform.localScale.x;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
            dir.x = transform.localScale.x;
        }



        if (Vector2.Distance(transform.position, walkPoint.walkpoints[walkPointIndex].position) < 0.1f)
        {
            if (walkPointIndex < walkPoint.walkpoints.Length - 1)
            {
                walkPointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}