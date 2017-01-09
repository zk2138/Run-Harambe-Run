using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreStart : MonoBehaviour {


    public Text high;
    public InputField input;
    static public string ime = "";

    void Start()
    {
        ime = "";
        if (PlayerPrefs.GetFloat("Highscore") > 0.0f)
        {
            high.text = "Highscore from player " + PlayerPrefs.GetString("highplayer") + " : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        }
        else
            high.text = "";

    }
    public void konec()
    {
        ime = input.text.ToString();
        if (ime.Length != 0)
        {
            input.enabled = false;
            input.text = "Hello, " + ime;
        }
        else
        {
            ime = "";
        }
    }
    public void IzDeathVStart()
    {
        if (ime != "")
        {
            SceneManager.LoadScene("HarambeField");
        }
        else
        {
            //OBRAVAJ RDECE
            ColorBlock cb = input.colors;
            cb.normalColor = Color.red;
            input.colors = cb;
        }
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
