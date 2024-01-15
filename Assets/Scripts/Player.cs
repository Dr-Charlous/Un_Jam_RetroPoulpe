using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int scoreValue = 0;
    public static float time = 0;
    private int lastTime = 0;
    private int currentTime = 0;


    void Start()
    {
        scoreValue = 10;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (lastTime != currentTime)
        {
            scoreValue += 10;
        }
        lastTime = currentTime;
        scoreValue += 10;
    }
}
