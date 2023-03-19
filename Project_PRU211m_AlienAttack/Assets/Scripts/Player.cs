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
    public Text WaveText;

    public int HeartInGame = 1000;
    public Text HeartText;


    public int GoldInGame = 100;
    public Text GoldText;

    private bool isPause = false;


    public GameOver1 gameover;
    public GameObject normal;
    public GameObject explo;
    public GameController GC;
    public Scoro a;
    void Start()
    {
        GC = FindObjectOfType<GameController>();
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


        if (HeartInGame <=0)
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
}
