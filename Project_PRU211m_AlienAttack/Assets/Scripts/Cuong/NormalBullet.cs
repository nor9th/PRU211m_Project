using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed; 
	private Vector3 movepoint ;
	private GameObject target ;



	private int atk; 
    void Start()
    {
        speed = 10;
    }
	public void gun(int atk , GameObject target)
	{
		this.target = target;
		this.atk = atk; 
	}
	// Update is called once per frame
	void Update()
    {
		if (target != null)
		{
			movepoint = target.transform.position;
			transform.position = Vector2.MoveTowards(transform.position, movepoint, speed * Time.deltaTime);
		}
		else
		{
			Destroy(gameObject);

		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
<<<<<<< Updated upstream
			//collision.GetComponent<TestEnemy>().health--;
			collision.GetComponent<HealthBoss>().DealDamage(5f);
=======
			//collision.GetComponent<HealthBoss>().DealDamage(atk);
			collision.GetComponent<AlienEnemy>().DealDamage(atk);
			//collision.GetComponent<LizardEnemy>().DealDamage(atk);
			//collision.GetComponent<RobotEnemy>().DealDamage(atk);
>>>>>>> Stashed changes
            Destroy(gameObject);
		}
	}

}
