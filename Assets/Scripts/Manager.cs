using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/ScriptableObject", order = 1)]
public class Manager : ScriptableObject
{
    public List<string> name = new List<string>();
    public List<int> score = new List<int>();
}