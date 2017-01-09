using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

    public InputField input;
    static public string ime = "";

    public void InstructionsToMain()
    {
        SceneManager.LoadScene("MainMenuStart");
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
    public void InstructionsToGame()
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

}
