using System.Collections;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    //public Color colorText1;
    //public Color colorText2;
    //public Color colorValue;

    void Update()
    {
        textInfo.SetText($"<color=blue>vitesse</color> <color=black>:</color> <color=red>{Player.speedValue} km/h</color>\n<color=blue>distance parcourue</color> <color=black>:</color> <color=red>{Mathf.Round(Player.scoreValue)} metres</color>\n ");
    }
}
