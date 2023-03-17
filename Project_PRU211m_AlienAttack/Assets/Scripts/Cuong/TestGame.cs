using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        
        if (a.Value == true)
        {
            gameObject.GetComponent<Player>().HeartInGame = PlayerPrefs.GetInt("Health");

            gameObject.GetComponent<Player>().WaveInGame = PlayerPrefs.GetInt("Wave");

            gameObject.GetComponent<Player>().TimeInGame = PlayerPrefs.GetFloat("Time");

            gameObject.GetComponent<Player>().GoldInGame = PlayerPrefs.GetInt("Gold");



            a.setValue(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;

        //score.text = count.ToString();
        if (count > 100)

        {
            GameOver();
        }
    }
    public void Saving()
    {

        PlayerPrefs.SetInt("Health", gameObject.GetComponent<Player>().HeartInGame);

        PlayerPrefs.SetInt("Wave", gameObject.GetComponent<Player>().WaveInGame);

        PlayerPrefs.SetFloat("Time", gameObject.GetComponent<Player>().TimeInGame);


        PlayerPrefs.SetInt("Gold", gameObject.GetComponent<Player>().GoldInGame);



        //score.text = count.ToString();
       
    }
    public void Saving()
    {
        PlayerPrefs.SetInt("Heart", gameObject.GetComponent<Player>().HeartInGame);
        Debug.Log(PlayerPrefs.GetFloat("Heart"));
        SceneManager.LoadScene("Start");
    }
    
}
