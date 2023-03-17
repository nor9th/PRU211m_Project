using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardEnemy : MonoBehaviour
{
    public float startSpeed = 20f;

    [HideInInspector]
    public float speed;

    //public GameObject deathEffect;
    //public Animation deathEffect;

    public float startHealth = 15;
    private float health;
    private int worth = 15;
    //public Image healthBar;

    public float MoveSpeed;
    private WalkPoint walkPoint;
    private int walkPointIndex;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        speed = startSpeed;
        walkPoint = GameObject.FindGameObjectWithTag("walkpoint").GetComponent<WalkPoint>();
    }

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
        transform.position = Vector2.MoveTowards(transform.position, walkPoint.walkpoints[walkPointIndex].position, MoveSpeed * Time.deltaTime);

        //Vector3 dir = walkPoint.walkpoints[walkPointIndex].position - transform.position;
        /*float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

        if (transform.position.x < walkPoint.walkpoints[walkPointIndex].position.x)
        {
            transform.localScale = new Vector3((float)1.5, (float)1.5, 0);
        }
        else
        {
            transform.localScale = new Vector3((float)-1.5, (float)1.5, 0);
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

    //Update is called once per frame
    //public void TakeDamage(float amount)
    //{
    //    health -= amount;

    //    healthBar.fillAmount = health / startHealth;

    //    if (health <= 0 && !isDead)
    //    {
    //        Die();
    //    }
    //}

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        //Animation effect = (Animation)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        //WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}