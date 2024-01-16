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
        textInfo.SetText($"<color=blue>Score</color> : {Player.scoreValue}\nSpeed : {Mathf.Round(Player.speedValue)} km/h\n ");
    }
}
