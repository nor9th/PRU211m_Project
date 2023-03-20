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


<<<<<<< Updated upstream
=======
    public GameOver1 gameover;
    public GameObject normal;
    public GameObject explo;
    public GameController GC;
    public Scoro a;
    public static Player player;
>>>>>>> Stashed changes
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
        HeartText.text = string.Format("Wave: " + HeartInGame);
        GoldText.text = string.Format("Wave: " + GoldInGame);
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
<<<<<<< Updated upstream
=======

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
>>>>>>> Stashed changes
        }
    }

    public void Awake()
    {
        player = this;
    }
}
