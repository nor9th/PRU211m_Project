using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float TimeInGame;
    public Text TimeText;

    public float CountTime;

    public int WaveInGame;
    public static int Wave;
    public Text WaveText;

    public static int Heart;
    public int HeartInGame;
    public Text HeartText;

    public static int Gold;
    public int GoldInGame;
    public Text GoldText;


    private bool isPause = false;
    public static Player player;

    public GameOver1 gameover;
    public GameObject normal;
    public GameObject explo;
    public GameController GC;
    public Scoro a;
    void Start()
    {
        Heart = HeartInGame;
        Gold = GoldInGame;
        GC = FindObjectOfType<GameController>();
        TimeInGame = 0f;
        CountTime = 0f;
    }

    void Update()
    {
        TimeInGame += Time.deltaTime;
        CountTime += Time.deltaTime;

        //if (CountTime >= 10f)
        //{
        //    CountTime = 0f;
            
        //}

        //countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        HeartText.text = string.Format("Heart: " + Heart);
        GoldText.text = string.Format("Gold: " + Gold);
        WaveText.text = string.Format("Wave: " + WaveInGame);
        TimeText.text = string.Format("Time: {0:00.00}", TimeInGame);


        if (Heart <= 0)
        {
            GameOver();
        }
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

    public void TimeIncrease()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
        }
        else if (Time.timeScale == 2)
        {
            Time.timeScale = 4;
        }
        else if (Time.timeScale == 4)
        {
            Time.timeScale = 1;
        }
    }
    public void GameOver()
    {
        gameObject.SetActive(false);
        gameover.setup();
    }

    public void Load()
    {

        for (int i = 0  ;i <a.NumTuret; i++)
        {
            Spawn(i);
            Debug.Log(a.NumTuret+"abc");
         }

    }

    private void Spawn(int s)
    {
        float x = PlayerPrefs.GetFloat("X"+s);
        float y = PlayerPrefs.GetFloat("Y"+s);

        Vector2 pos = new Vector2(x, y);
       //  int Level = PlayerPrefs.GetInt("Level" + s);
         int type =  PlayerPrefs.GetInt("Type" + s);
        if (type == 0)
        {
          GameObject sq =  Instantiate(normal, pos, Quaternion.identity); 
         //   sq.GetComponent<NormalGun>().Level = Level;
        }
		if (type == 1)

		{
			GameObject sq = Instantiate(explo, pos, Quaternion.identity);
           // sq.GetComponent<ExplosionGun>().Level = Level;


        }


    }

    public void Awake()
    {
        player = this;
    }
}
