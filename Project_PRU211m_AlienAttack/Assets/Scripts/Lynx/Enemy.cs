using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float speed = 10f;

    //private Transform target;
    //private int wavepointIndex;

    public float MoveSpeed;
    private WalkPoint walkPoint;
    private int walkPointIndex;

    //private WalkPoint walkPoint;
    //private int walkPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        walkPoint = GameObject.FindGameObjectWithTag("walkpoint").GetComponent<WalkPoint>();
        //target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Vector3 dir = target.position - transform.position;
        //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        //{
        //    GetNextWaypoint();
        //    //return;
        //}
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Waypoints.points[walkPointIndex].position, MoveSpeed * Time.deltaTime);

        //Vector3 dir = walkPoint.walkpoints[walkPointIndex].position - transform.position;
        /*float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

        if (transform.position.x < Waypoints.points[walkPointIndex].position.x)
        {
            transform.localScale = new Vector3((float)0.5, (float)0.5, 0);
        }
        else
        {
            transform.localScale = new Vector3((float)-0.5, (float)0.5, 0);
        }



        if (Vector2.Distance(transform.position, Waypoints.points[walkPointIndex].position) < 0.1f)
        {
            if (walkPointIndex < Waypoints.points.Length - 1)
            {
                walkPointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }*/
    }

    //void GetNextWaypoint()
    //{
    //    if (wavepointIndex >= Waypoints.points.Length -1)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    wavepointIndex++;
    //    target = Waypoints.points[wavepointIndex];
    //}
}
