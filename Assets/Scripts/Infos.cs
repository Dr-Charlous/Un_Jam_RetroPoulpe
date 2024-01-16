using System.Collections;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public Color colorText1;
    public Color colorText2;
    public Color colorValue;

    void Update()
    {
        textInfo.SetText($"<color=#{ColorUtility.ToHtmlStringRGB(colorText1)}>vitesse</color> <color=black>:</color> <color=#{ColorUtility.ToHtmlStringRGB(colorValue)}>{Player.speedValue} km/h</color>\n" +
            $"<color=#{ColorUtility.ToHtmlStringRGB(colorText2)}>distance parcourue</color> <color=black>:</color> <color=#{ColorUtility.ToHtmlStringRGB(colorValue)}>{Mathf.Round(Player.scoreValue)} metres</color>\n ");
    }
}
