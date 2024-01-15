using System.Collections;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    public TextMeshProUGUI textInfo;

    void Update()
    {
        textInfo.SetText($"Score : {Player.scoreValue}\nSpeed : {Mathf.Round(Player.speedValue)} km/h\n ");
    }
}
