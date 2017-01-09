using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreStart : MonoBehaviour {

    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;
    private int max = 0;
    private string temp = "";
    private int tempi = 0;
    public Text high;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;

        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split('\n'));
        int num = eachLine.Count - 1;
        for(int i = 0; i < num; i++)
        {
            temp = eachLine[i].Substring(eachLine[i].LastIndexOf(" ") + 1);
            tempi = int.Parse(temp);
            if (tempi > max)
                max = tempi;
        }
        high.text = max.ToString();
    }
}
