using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxManager : MonoBehaviour
{
    public Material[] Materials;
    public GameObject[] Deco;
    public GameObject[] Bonus;
    // Start is called before the first frame update
    public void UpdateParallax(float PlayerSpeed, float PlayerPosX)
    {
        foreach (Material mat in Materials)
        {
            mat.SetFloat("_PlayerSpeed", PlayerSpeed);
        }


        if (Random.Range(1, 1000) == 2)
        {
            float t = 2;
            GameObject go = GameObject.Instantiate(Deco[Random.Range(0, Deco.Length)], new Vector3(PlayerPosX + 25, 15, 2), Quaternion.identity);
            /*while (t > 0)
            {
                t -= Time.deltaTime;

            }
            Destroy(go);*/
        }
        if (Random.Range(1, 500) == 2)
        {
            float t = 2;
            GameObject go = GameObject.Instantiate(Bonus[Random.Range(0, Bonus.Length)], new Vector3(PlayerPosX + 25, Random.Range(5,10), 0), Quaternion.identity);
            
        }
    }
}
