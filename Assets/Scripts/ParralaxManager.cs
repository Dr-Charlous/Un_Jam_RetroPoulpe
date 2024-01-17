using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxManager : MonoBehaviour
{
    public Material[] Materials;
    // Start is called before the first frame update
    public void UpdateParallax(float PlayerSpeed)
    {
        foreach (Material mat in Materials)
        {
            mat.SetFloat("_PlayerSpeed", PlayerSpeed);
        }
    }
}
