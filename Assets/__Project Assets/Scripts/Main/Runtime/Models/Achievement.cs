using d4160.Core.Attributes;
using d4160.GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement : DefaultArchetype
{
    [TextArea]
    public string description;
    public Sprite sprite;
}

