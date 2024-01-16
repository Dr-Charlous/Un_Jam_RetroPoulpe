using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public int numberScoreName = 10;
    public Manager manager;
    private TextMeshProUGUI text;
    private List<string> nameDisplay = new List<string>();
    private List<int> scoreDisplay = new List<int>();
    private int max = 0;
    private int index;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void RefreshScoreBoard()
    {
        text = GetComponent<TextMeshProUGUI>();

        nameDisplay = manager.name;
        scoreDisplay = manager.score;

        text.text = "";

        for (int i = 0; i < numberScoreName; i++)
        {
            FindMax(scoreDisplay);
            if (max != -1)
            {
                text.text += $"{nameDisplay[index]} - ";
                for (int j = 0;  j < 8-max.ToString().Length; j++)
                {
                    text.text += "0";
                }
                text.text += $"{max}\n";
            }
            else
            {
                text.text += "Empty - 00000000\n";
            }

            nameDisplay[index] = " ";
            scoreDisplay[index] = -1;
        }
    }

    void FindMax(List<int> list)
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

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
