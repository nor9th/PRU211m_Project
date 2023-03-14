using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        
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
        if (canClick)
        {
            screenPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            transform.position = worldPosition;
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
                turretPoint = hit.transform.position;
                UIManager.UI.TurretShop.SetActive(false);
                Debug.Log("ban2");

            }
        }
    }
}
