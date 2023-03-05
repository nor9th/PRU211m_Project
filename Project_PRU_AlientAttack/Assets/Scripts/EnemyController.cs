using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyController : MonoBehaviour
{
    public int hp;
    public float speed;
    public int gold;
    private float moveRange;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    [SerializeField] private Vector2 moveRandom;
    // Start is called before the first frame update
    void Start()
    {
        moveRandom = new Vector2(Random.Range(-transform.position.x, transform.position.x + moveRange),
                                        Random.Range(-transform.position.y, transform.position.y + moveRange));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        if (currentPos == moveRandom)
        {
            GeneratePoint();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveRandom, speed * Time.deltaTime);
        }
    }

    private void GeneratePoint()
    {
        moveRandom = new Vector2(Random.Range(-5, 5), Random.Range(-4, 4));
    }
}
