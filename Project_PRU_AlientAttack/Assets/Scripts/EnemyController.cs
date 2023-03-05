using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public float speed;
    public int gold;

    public Rigidbody2D rb;

   public void Init()
    {
        health = maxHealth;
    }
}
