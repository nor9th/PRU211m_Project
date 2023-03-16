using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float TimeInGame;
    public Text TimeText;

    private float CountTime;

    private int WaveInGame;
    public Text WaveText;

    private int HeartInGame = 10;
    public Text HeartText;

    private int GoldInGame = 100;
    public Text GoldText;

    private bool isPause = false;


    void Start()
    {
        TimeInGame = 0f;
        CountTime = 0f;
    }

    void Update()
    {
        TimeInGame += Time.deltaTime;
        CountTime += Time.deltaTime;

        if (CountTime >= 10f)
        {
            CountTime = 0f;
            WaveInGame++;
            HeartInGame -= 1;
            for (int i = 0; i < WaveInGame; i++)
            {
                GoldInGame += (i * 100);
            }
            
        }

        //countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        HeartText.text = string.Format("Heart: " + HeartInGame);
        GoldText.text = string.Format("Gold: " + GoldInGame);
        WaveText.text = string.Format("Wave: " + WaveInGame);
        TimeText.text = string.Format("Time: {0:00.00}", TimeInGame);
    }

    void PauseGame()
    {
        if(!isPause)
        {
            isPause = true;
            TimeInGame = Time.deltaTime;
            TimeInGame = Time.timeScale;
        }
    }
}
