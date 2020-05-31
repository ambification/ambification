using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class QuestsSO : ScriptableObject
{
    public AchievementsSO achievementsSO;
    public List<Quest> quests;

    private string[] AchievementNames => achievementsSO.achievements.Select(x => x.Name).ToArray();
}
