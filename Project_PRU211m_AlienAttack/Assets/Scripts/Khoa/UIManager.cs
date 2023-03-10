using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager UI;
    public GameObject TurretShop;
    
    public void Awake()
    {
        UI= this;
    }

    public void CloseTurretShopPanel()
    {
        TurretShop.SetActive(false);
    }
}
