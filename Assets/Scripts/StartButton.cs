using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            mAnimator.SetTrigger("Press Start");
        }
    }
}
