using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TestGame : MonoBehaviour
{
    // Start is called before the first frame update
    public float count = 0;
    public GameOver1 gameover;
    public Scoro a ;
    public int i = 0;
   public GameController GC;
    void Start()
    {
        GC = FindObjectOfType<GameController>();
        if (a.Value == true)
        {
            gameObject.GetComponent<Player>().HeartInGame = PlayerPrefs.GetInt("Health");

            gameObject.GetComponent<Player>().WaveInGame = PlayerPrefs.GetInt("Wave");

            gameObject.GetComponent<Player>().TimeInGame = PlayerPrefs.GetFloat("Time");

            gameObject.GetComponent<Player>().GoldInGame = PlayerPrefs.GetInt("Gold");

            gameObject.GetComponent<Player>().Load();

            a.setValue(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;

      
    }
    public void Saving()
    {

        PlayerPrefs.SetInt("Health", gameObject.GetComponent<Player>().HeartInGame);

        PlayerPrefs.SetInt("Wave", gameObject.GetComponent<Player>().WaveInGame);

        PlayerPrefs.SetFloat("Time", gameObject.GetComponent<Player>().TimeInGame);


        PlayerPrefs.SetInt("Gold", gameObject.GetComponent<Player>().GoldInGame);

     

        foreach (GameObject g in GC.ListTurret)
        {
            Debug.Log(a.NumTuret);
            if (g.tag == "Normal")
            {
                PlayerPrefs.SetFloat("X" + a.NumTuret, g.transform.position.x);
                PlayerPrefs.SetFloat("Y" + a.NumTuret, g.transform.position.y);
                PlayerPrefs.SetInt("Type" + a.NumTuret, 0);
            }
			if (g.tag == "Explosion")
			{
				PlayerPrefs.SetFloat("X" + a.NumTuret, g.transform.position.x);
                PlayerPrefs.SetFloat("Y" + a.NumTuret, g.transform.position.y);
                PlayerPrefs.SetInt("Type" + a.NumTuret, 1);
            }
            a.setNum(1);
			//i++;


		}
		SceneManager.LoadScene("Start");



    }


}
