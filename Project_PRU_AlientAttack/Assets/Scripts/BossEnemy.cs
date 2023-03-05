using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float DeathCoinReward;
    [SerializeField] private WalkPoint WalkPoint;

    public static Action<BossEnemy> OnEndReached;
    private HealthBoss bossHealth;

    private int currentWalkPointIndex;
    private Vector3 CurrentPointPosition;
    private Vector3 lastPointPosition;
    private SpriteRenderer spriteRenderer;




    // Start is called before the first frame update
    void Start()
    {
        CurrentPointPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWalkPointIndex = WalkPoint.Point.Length - 1;
        if(currentWalkPointIndex < lastWalkPointIndex)
        {
            currentWalkPointIndex++;
        }
        else
        {
            EndPointReached();
        }
    }

    private void EndPointReached()
    {
        OnEndReached?.Invoke(this);
        bossHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }

    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if(distanceToNextPointPosition < 0.1f)
        {
            lastPointPosition = transform.position;
            return true;
        }
        return false;
    }

    private void Rotate()
    {
        if(CurrentPointPosition.x > lastPointPosition.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, MoveSpeed * Time.deltaTime);

    }
}
