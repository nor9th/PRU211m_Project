using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LizardEnemy : MonoBehaviour
{
    public float startSpeed = 20f;

    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    public float startHealth = 15;
    private float health;
    private float worth = 15;
    public Image healthBar;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        speed = 10;
    }

    // Update is called once per frame
    //public void TakeDamage(float amount)
    //{
    //    health -= amount;

    //    healthBar.fillAmount = health / startHealth;

    //    if (health <= 0 && !isDead)
    //    {
    //        Die();
    //    }
    //}

    //void Die()
    //{
    //    isDead = true;

     //   PlayerStats.Money += worth;

    //    GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, 5f);

    //    WaveSpawner.EnemiesAlive--;

    //    Destroy(gameObject);
    //}
}
