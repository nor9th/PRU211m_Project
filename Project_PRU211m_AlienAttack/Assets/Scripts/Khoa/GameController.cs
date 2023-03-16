using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layer;
    public LayerMask Gunlayer;
    public Vector3 turretPoint;
    public bool canClick = true;
    public float GameTime;
    public GameObject Turret;
    
    
    void Start()
    {
        Time.timeScale= GameTime;
    }
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    public void Click()
    {
        if (canClick == true)
        {
            screenPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            Collider2D hit = Physics2D.OverlapCircle(worldPosition, .5f, layer);
            Collider2D hit1 = Physics2D.OverlapCircle(worldPosition, .5f, Gunlayer);

            if (hit != null && hit1 == null)
            {
                turretPoint = hit.transform.position;
                UIManager.UI.TurretShop.SetActive(true);
                canClick = false;


                Debug.Log("ban");
            }
            if (hit != null && hit1 != null)
            {
                turretPoint = hit1.transform.position;
                UIManager.UI.TurretShop.SetActive(false);
                Turret = hit1.gameObject;
                if (Turret == null)
                {
                    Debug.Log("null");
                }
                UIManager.UI.TurretInfo.SetActive(true);
                canClick = false;
                
                Debug.Log("ban2");

            }
        }
    }

    public void TimeScale()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 1;
        }
    }
}
