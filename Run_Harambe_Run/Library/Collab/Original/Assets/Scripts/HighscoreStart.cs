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
    private int[] scores;
    private string[] names;
    private string[] lines;

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

        lines = eachLine.ToArray();
        int size = lines.Length-1;
        names = new string[size];
        scores = new int[size];
        for(int i = 0; i < size; i++)
        {
            string[] split = lines[i].Split(' ');
            int res = int.Parse(split[1]);
            names[i] = split[0];
            scores[i] = res;
        }

        System.Array.Sort(scores, names);
        System.Array.Reverse(scores);
        System.Array.Reverse(names);

        for (int i = 0; i < size; i++)
        {
            Debug.Log(names[i] + " " + scores[i]);
        }
    }
}
