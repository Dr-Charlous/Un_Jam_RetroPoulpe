using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int scoreValue = 0;
    public  static float speedValue = 0;
    public static float time = 0;
    public Manager manager;

    public Image hungryBarFull;
    public static float hungry = 100f;

    public Image lubricantBarFull;
    public static float lubricant = 100f;

    private int lastTime = 0;
    private int currentTime = 0;


    private void Start()
    {
        StartCoroutine(CalculateSpeed());
    }

    void Update()
    {
        time += Time.deltaTime;
        currentTime = Mathf.FloorToInt(time);

        if (lastTime != currentTime) // Every second
        {
            scoreValue += 10;
            MoreHungry(10);
            LessLubricant(20);
        }
        lastTime = currentTime;

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameOver();
        }
    }

    // Speed

    IEnumerator CalculateSpeed()
    {
        while (true)
        {
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            speedValue = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);
        }
    }

    // Hungry

    public void MoreHungry(float notEating)
    {
        hungry -= notEating;
        hungryBarFull.fillAmount = hungry / 100;
    }

    public void LessHungry(float eating)
    {
        hungry += eating;
        hungryBarFull.fillAmount = Mathf.Clamp(eating, 0, 100);

        hungryBarFull.fillAmount = hungry / 100;
    }

    // Lubricant

    public void MoreLubricant(float wet)
    {
        lubricant += wet;
        lubricantBarFull.fillAmount = lubricant / 100;
    }

    public void LessLubricant(float dry)
    {
        lubricant -= dry;
        lubricantBarFull.fillAmount = Mathf.Clamp(dry, 0, 100);

        lubricantBarFull.fillAmount = lubricant / 100;
    }

    // GameOver

    public void GameOver()
    {
        manager.score.Add(scoreValue);
        manager.name.Add("GameOver");
        SceneManager.LoadScene("ScoreBoardScene");
    }
}
