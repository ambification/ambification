using d4160.Core.Attributes;
using d4160.GameFramework;
using System.Collections.Generic;

[System.Serializable]
public class Quest : DefaultArchetype
{
    public List<Task> tasks;
    [Dropdown(ValuesProperty = "AchievementNames")]
    public List<int> achievements;
}