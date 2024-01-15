using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int scoreValue = 0;
    public  static float speedValue = 0;
    public static float time = 0;
    private int lastTime = 0;
    private int currentTime = 0;

    private void Start()
    {
        StartCoroutine(CalcSpeed());
    }

    void Update()
    {
        time += Time.deltaTime;
        currentTime = Mathf.FloorToInt(time);

        if (lastTime != currentTime) // A chaque seconde
        {
            scoreValue += 10;
        }
        lastTime = currentTime;

    }

    IEnumerator CalcSpeed()
    {
        while (true)
        {
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            speedValue = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);
        }
    }
}
