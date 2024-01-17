using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxManager : MonoBehaviour
{
    public Material[] Materials;
    public GameObject[] Deco;
    // Start is called before the first frame update
    public void UpdateParallax(float PlayerSpeed, float PlayerPosX)
    {
        foreach (Material mat in Materials)
        {
            mat.SetFloat("_PlayerSpeed", PlayerSpeed);
        }

        if (Random.Range(1,100)==2)
        {
            GameObject.Instantiate(Deco[Random.Range(0, Deco.Length)], new Vector3(PlayerPosX, 10, 0), Quaternion.identity);
        }
    }
}
