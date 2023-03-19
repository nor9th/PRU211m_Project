using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NormalGun : MonoBehaviour
{
    // Start is called before the first frame update
    private int Atk;
    private int Range;
    private int Gold;
    public int Level;
    private int Reload;

    public GameObject bullet;
    public GameObject Normal_gun; 
    public UnityEngine.Transform Spot;
	public float counter = 0;
    public int z = 0;
	public GameObject CurrentEnemy  ;

	void Start()
    {
        Atk = 5;
        Range = 10;
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

        if (CurrentEnemy == null)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), Range);
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].tag == "Enemy" && hit.Length >= 1)
                {

                    CurrentEnemy = hit[i].gameObject;

                  
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, CurrentEnemy.transform.position) <= Range)
            {
                Vector2 lookDir = CurrentEnemy.transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                if (counter > Reload)
                {
                    GameObject obj = Instantiate<GameObject>(bullet, Spot.position, Normal_gun.transform.rotation);
                    if (CurrentEnemy == null)
                    {
                        Destroy(obj.GetComponent<NormalBullet>());

                    }
                    obj.GetComponent<NormalBullet>().gun(Atk, CurrentEnemy.gameObject);
                    counter = 0;
                }
            }
            else
            {
                CurrentEnemy = null;

            }
        }
	}
    public bool isNormal()
    {
        return true;
    }
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position,Range); 
	}
}

