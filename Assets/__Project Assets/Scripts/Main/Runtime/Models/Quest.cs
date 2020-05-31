using d4160.Core.Attributes;
using d4160.GameFramework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest : DefaultArchetype
{
    [TextArea]
    public string description;
    public List<Task> tasks;
    [Dropdown(ValuesProperty = "AchievementNames")]
    public List<int> achievements;
}