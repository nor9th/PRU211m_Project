using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HealthBoss : MonoBehaviour
{
    public static Action<BossEnemy> OnBossKilled;
    public static Action<BossEnemy> OnBossHit;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    public AudioSource audio;

    public float CurrentHealth { get; set; }
    private Image healthBar;
    private BossEnemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
        
        enemy = GetComponent<BossEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
        }*/
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, CurrentHealth/maxHealth, Time.deltaTime * 10f);
    }

    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        BossHealthBar bhb = newBar.GetComponent<BossHealthBar>();
        healthBar = bhb.FillAmountImage;
    }

    public void DealDamage(float damage)
    {
		CurrentHealth = CurrentHealth - damage;
        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
            audio.Play();
            Die();
        }
        else
        {
            OnBossHit?.Invoke(enemy);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    internal void ResetHealth()
    {
        CurrentHealth = 0;
    }
}
