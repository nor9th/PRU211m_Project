using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class AlienEnemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    //public GameObject deathEffect;
    //public Animator deathEffect;

    public float startHealth = 10;
    private float health;
    private int worth = 10;
    //public Image healthBar;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        speed = startSpeed;
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

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        //WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}
