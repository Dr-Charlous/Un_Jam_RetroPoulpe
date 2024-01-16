using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public int numberScoreName = 10;
    public Manager manager;
    private TextMeshProUGUI text;
    private List<string> name = new List<string>();
    private List<int> score = new List<int>();
    private int max = 0;
    private int index;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        name = manager.name;
        score = manager.score;

        name.Add("Name01");
        score.Add(10);

        text.text = "";

        for (int i = 0; i < numberScoreName; i++)
        {
            findMax(score);
            if (max != -1)
            {
                text.text += $"{name[index]} - ";
                for (int j = 0;  j < 6-max.ToString().Length; j++)
                {
                    text.text += "0";
                }
                text.text += $"{max}\n";
            }
            else
            {
                text.text += "Empty - 000000\n";
            }

            name[index] = " ";
            score[index] = -1;
        }
    }

    void findMax(List<int> list)
    {
        max = -1;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] > max)
            {
                max = list[i];
                index = i;
            }
        }
    }
}
