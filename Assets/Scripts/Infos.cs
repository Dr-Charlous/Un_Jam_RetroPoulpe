using System.Collections;
using TMPro;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public GameObject player;

    void Update()
    {
        textInfo.SetText($"Score : {Player.scoreValue}\n test");
    }
}
