using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInfo : MonoBehaviour
{
    public static TurretInfo turretInfo;
    public GameController GC;
    public Text Level;
    public Text Attack;
    public Text Range;
    public Text Reload;
    public Text Gold;
    void Start()
    {
        GC = FindObjectOfType<GameController>();
    }

    void Update()
    {
        
    }

    public void setInfoText(string txt,string atk,string reload, string range, string gold)
    {
        if (Level != null)
        {
            Level.text = txt;
        }
        if (Attack != null)
        {
            Attack.text = atk;
        }
        if (Reload != null)
        {
            Reload.text = reload;
        }
        if (Range != null)
        {
            Range.text = range;
        }
        if (Gold != null)
        {
            Gold.text = gold;
        }

    }

    public void Awake()
    {
        turretInfo = this;
    }
}
