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
    public GameObject Turret;

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
                
            }
            if (hit != null && hit1 != null)
            {
                int gunAtk=0;
                int gunRange = 0;
                int gunReload = 0;
                int gunGold = 0;
                turretPoint = hit.transform.position;
                UIManager.UI.TurretShop.SetActive(false);
                Turret = hit1.gameObject;
                if (Turret.CompareTag("NormalGun"))
                {
                    NormalGun normalGun = Turret.GetComponent<NormalGun>();
                    gunAtk = normalGun.Atk;
                    gunRange = normalGun.Range;
                    gunReload = normalGun.Reload;
                    gunGold = normalGun.Gold;

                }
                else if (Turret.CompareTag("ExplosionGun"))
                {
                    ExplosionGun explosionGun = Turret.GetComponent<ExplosionGun>();
                    gunAtk = explosionGun.Atk;
                    gunRange = explosionGun.Range;
                    gunReload = explosionGun.Reload;
                    gunGold= explosionGun.Gold;
                }
                if (Turret == null)
                {
                    Debug.Log("null");
                }
                UIManager.UI.TurretInfo.SetActive(true);
                canClick = false;
                TurretInfo.turretInfo.setInfoText("Level: 1","Attack: " + gunAtk,"Reload: " + gunReload,"Range: "+ gunRange,"Gold: " + gunGold);

            }
        }
    }
}
