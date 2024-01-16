using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnterName : MonoBehaviour
{
    public GameObject okBtn;
    public TMP_InputField inputField;
    public Manager manager;
    private void Awake()
    {
        okBtn = GetComponent<GameObject>();
        inputField = GetComponent<TMP_InputField>();
    }

    public void AddName()
    {
        manager.name.Add(inputField.text);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
