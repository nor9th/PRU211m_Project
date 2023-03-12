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

    public TurretSettings TurretLoaded { get; set; }

    public void SetupTurretButton(TurretSettings turretSettings)
    {
        TurretLoaded = turretSettings;
        turretImage.sprite = turretSettings.TurretShopSprite;
        turretCost.text = turretSettings.TurretShopSprite.ToString();
    }

    public void PlaceTurret()
    {
        Vector3 vector = new Vector3(-5.2238f, -8.5208f, 0);
        UIManager.UI.CloseTurretShopPanel();
        //OnPlaceTurret?.Invoke(TurretLoaded);
        Instantiate(TurretLoaded.TurretPrefabs, vector, Quaternion.identity);
        Debug.Log("turret Create");
    }
}
