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
            count = PlayerPrefs.GetFloat("Score");
            a.setValue(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;
        //score.text = count.ToString();
        if (count > 10)
        {
            GameOver();
        }
    }
    public void Saving()
    {
        //PlayerPrefs.SetFloat("Score", count);
        //Debug.Log(PlayerPrefs.GetFloat("Score"));
        SceneManager.LoadScene("Start");
    }
    public void GameOver()
    {
        gameObject.SetActive(false);
        gameover.setup();
    }
}
