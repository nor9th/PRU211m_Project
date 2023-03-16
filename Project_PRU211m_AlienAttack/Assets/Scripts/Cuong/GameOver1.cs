using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text points;
    public void setup()
    {
        gameObject.SetActive(true);
    }
    public void menu()
    {
        SceneManager.LoadScene("EndGame");
    }
    public void restart()
    {
        SceneManager.LoadScene("Start");

    }
}
