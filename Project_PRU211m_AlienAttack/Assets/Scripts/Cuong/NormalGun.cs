using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NormalGun : MonoBehaviour
{
    // Start is called before the first frame update
    private int Atk;
    private int Range;
    private int Gold;
    private int Level;
    private int Reload;

    public GameObject bullet;
    public GameObject Normal_gun; 
    public UnityEngine.Transform Spot;
	public float counter = 0;

	void Start()
    {
        Atk = 5;
        Range = 20;
        Reload = 2;
        Gold = 30; 
        Level= 1;   
    }

    // Update is called once per frame
    void Update()
    {
		counter = counter + Time.deltaTime;
		Rotate();
	}
	private void Rotate()
	{
		Collider2D[] hit = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), Range);
        for(int i = 0; i < hit.Length;i++)
        {
            if (hit[i].tag == "Enemy" && hit.Length >= 1)
            {
                Vector2 lookDir = hit[i].transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                if (counter > Reload)
                {
                    GameObject obj = Instantiate<GameObject>(bullet, Spot.position, Normal_gun.transform.rotation);
                    obj.GetComponent<NormalBullet>().gun(Atk, hit[i].gameObject);
                    counter = 0;
                }
            }
        }
		

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position,Range); 
	}
}

