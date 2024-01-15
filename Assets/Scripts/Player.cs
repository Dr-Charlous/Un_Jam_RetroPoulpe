using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int scoreValue = 0;
    public  static float speedValue = 0;
    public static float time = 0;

    public Image healthBar;
    public static float health = 100f;

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
            TakeDamage(10);
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health/100;
    }

    public void Heal(float healing)
    {
        health += healing;
        healthBar.fillAmount = Mathf.Clamp(healing, 0, 100);

        healthBar.fillAmount = health/100;
    }
}
