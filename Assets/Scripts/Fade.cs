using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float alphaSpeed = .001f;

    private Image image;
    private float alpha;
    private bool anim;

    void Start()
    {
        image = GetComponent<Image>();
        alpha = 0;
        image.color = new Color(0, 0, 0, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            anim = true;
        }

        if (anim)
        {
            alpha += alphaSpeed;
            image.color = new Color(0, 0, 0, alpha);
            if (alpha > 1)
            {
                SceneManager.LoadScene("CoquoScene");
            }
        }
    }
}
