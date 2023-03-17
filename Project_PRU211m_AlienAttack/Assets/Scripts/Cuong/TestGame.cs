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
    public Text score;
    public Button b;
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
<<<<<<< Updated upstream
        score.text = count.ToString();
        if (count > 10)
=======
        //score.text = count.ToString();
        if (count > 100)
>>>>>>> Stashed changes
        {
            GameOver();
        }
    }
    public void Saving()
    {
<<<<<<< Updated upstream
        PlayerPrefs.SetFloat("Score", count);
=======
        PlayerPrefs.SetInt("Health", gameObject.GetComponent<Player>().HeartInGame);

        PlayerPrefs.SetInt("Wave", gameObject.GetComponent<Player>().WaveInGame);

        PlayerPrefs.SetFloat("Time", gameObject.GetComponent<Player>().TimeInGame);


        PlayerPrefs.SetInt("Gold", gameObject.GetComponent<Player>().GoldInGame);


>>>>>>> Stashed changes
        Debug.Log(PlayerPrefs.GetFloat("Score"));
        SceneManager.LoadScene("Start");
    }
    public void GameOver()
    {
gameObject.SetActive(false);
        gameover.setup();

    }
}
