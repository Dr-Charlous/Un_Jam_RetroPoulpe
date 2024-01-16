using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerOilFade : MonoBehaviour
{
    public Material PoulpeMaterial;
    private Color OriginColor;
    private bool IsBlack;

    private void Update()
    {
       
    }
    private void Start()
    {
        OriginColor = PoulpeMaterial.GetColor("_BaseColor");
    }
    void SwitchOilState(float TransitionDuration)
    {
        if (!IsBlack)
        {
            DOVirtual.Color(OriginColor, Color.black, TransitionDuration, (value) =>
            {
                PoulpeMaterial.SetColor("_BaseColor", value);
                Debug.Log(value);
            });
           
            IsBlack = true;
        }
        else
        {
            DOVirtual.Color(Color.black,OriginColor, TransitionDuration, (value) =>
            {
                PoulpeMaterial.SetColor("_BaseColor", value);
                Debug.Log(value);
            });
            IsBlack = false;
        }
        
    }
}
