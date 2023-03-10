using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurretCard : MonoBehaviour
{
    public static Action<TurretSettings> OnPlaceTurret;
    [SerializeField] private Image turretImage;
    [SerializeField] private Text turretCost;
    public GameController GC;

    void Start()
    {
        GC = FindObjectOfType<GameController>();
    }
    public TurretSettings TurretLoaded { get; set; }

    public void SetupTurretButton(TurretSettings turretSettings)
    {
        TurretLoaded = turretSettings;
        turretImage.sprite = turretSettings.TurretShopSprite;
        turretCost.text = turretSettings.TurretShopSprite.ToString();
    }

    public void PlaceTurret()
    {
        UIManager.UI.CloseTurretShopPanel();
        Instantiate(TurretLoaded.TurretPrefabs, GC.turretPoint, Quaternion.identity);
        Debug.Log("turret Create");
    }
}
