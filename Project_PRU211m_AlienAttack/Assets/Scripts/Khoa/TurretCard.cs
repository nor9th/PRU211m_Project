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
        turretCost.text = turretSettings.TurretShopCost.ToString();
    }

    public void PlaceTurret()
    {
<<<<<<< Updated upstream
        UIManager.UI.CloseTurretShopPanel();
        Instantiate(TurretLoaded.TurretPrefabs, GC.turretPoint, Quaternion.identity);
        Debug.Log("turret Create");
        GC.canClick = true;
=======
        Debug.Log(PlayerStats.Money);
        if (int.Parse(turretCost.text) <= Player.player.GoldInGame)
        {
            UIManager.UI.CloseTurretShopPanel();
            GameObject a = Instantiate(TurretLoaded.TurretPrefabs, GC.turretPoint, Quaternion.identity);
            GC.ListTurret.Add(a);
            Debug.Log("turret Create");
            GC.canClick = true;
            Player.player.GoldInGame = Player.player.GoldInGame - int.Parse(turretCost.text);
        }
        
>>>>>>> Stashed changes
    }
}
