using d4160.Core.Attributes;
using d4160.GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public string name;
    [TextArea]
    public string description;
    public int score;
}