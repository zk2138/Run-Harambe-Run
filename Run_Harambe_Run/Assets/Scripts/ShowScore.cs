using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour
{

    string ime;
    float score;
    public Text scoreText;
    public AudioSource scream;

    // Use this for initialization
    void Start()
    {
        scream.Play();
        score = Score.score;
        ime = HighscoreStart.ime;
        if (PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
            PlayerPrefs.SetString("highplayer", ime);
            scoreText.text = "You beat the record ! Score : " + ((int)score).ToString();
        }
        else
        {
            scoreText.text = "Score : " + ((int)score).ToString();
        }
    }
    public void ScoreToGame()
    {
        SceneManager.LoadScene("HarambeField");
    }

    public void ScoreToStart()
    {
        SceneManager.LoadScene("MainMenuStart");
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
