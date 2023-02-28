using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGun : MonoBehaviour
{
    // Start is called before the first frame update
    private int Atk;
    private int Range;
    private int Gold;
    private int Level;
    private int Reload;

    private GameObject bullet; 
    void Start()
    {
        Atk = 5;
        Range = 100;
        Reload = 2;
        Gold = 30; 
        Level= 1;   
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
    public void Check()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] enemys = Physics2D.OverlapCircleAll(pos,Range);
        for(int i = 0; i< enemys.Length; i++)
        {
            if (enemys[i].tag =="enemy") {
                GameObject obj = Instantiate<GameObject>(bullet, transform.position, transform.rotation);
            }
        }
    }
}
