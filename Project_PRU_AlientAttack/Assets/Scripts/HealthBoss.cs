using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HealthBoss : MonoBehaviour
{
    public static Action<BossEnemy> OnEnemyKilled;
    public static Action<BossEnemy> OnEnemyHit;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DealDamage(5f);
        }
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, CurrentHealth/maxHealth, Time.deltaTime * 10f);
    }

    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        BossHealthBar bhb = newBar.GetComponent<BossHealthBar>();
        healthBar = bhb.FillAmountImage;
    }

    private void DealDamage(float damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
            //Die();
        }
        else
        {
            OnEnemyHit?.Invoke(enemy);
        }
    }
}
