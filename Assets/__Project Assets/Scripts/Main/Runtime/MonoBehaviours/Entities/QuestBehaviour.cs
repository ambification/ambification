using d4160.Core.Attributes;
using d4160.GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityExtensions;
using d4160.Core;
using UltEvents;

public class QuestBehaviour : MonoBehaviour
{
    [Dropdown(ValuesProperty = "QuestNames")]
    public int selected;
    [InspectInline(canEditRemoteTarget = true, canCreateSubasset = true)]
    public QuestsSO questsSO;

    public Quest SelectedQuest => questsSO.quests[selected];

    private string[] QuestNames => questsSO?.quests.Select(x => x.Name).ToArray() ?? new string[0];

    [SerializeField] private bool[] _doneTaskTracking;
    [SerializeField] private bool[] _unlockedAchievementTracking;

    public UltEvent onTaskValueChanged;

    public bool[] DoneTaskTracking => _doneTaskTracking;
    public bool[] UnlockedAchievementTracking => _unlockedAchievementTracking;

    public Task GetSelectedTask(int idx) => SelectedQuest.tasks[idx];

    private void Awake()
    {
        _doneTaskTracking = new bool[SelectedQuest.tasks.Count];
        _unlockedAchievementTracking = new bool[SelectedQuest.achievements.Count];
    }

    public void SetCompleteTask(bool val, int index = 0)
    {
        if (_doneTaskTracking.IsValidIndex(index))
        {
            _doneTaskTracking[index] = val;

            onTaskValueChanged?.Invoke(val, index);
        }
    }

    public void UnlockAchievement(bool val, int index = 0)
    {
        if (_unlockedAchievementTracking.IsValidIndex(index))
        {
            _unlockedAchievementTracking[index] = val;
        }
    }

    public bool CheckCompleteQuest()
    {
        bool completed = true;
        for (int i = 0; i < _doneTaskTracking.Length; i++)
        {
            if (!_doneTaskTracking[i])
            {
                completed = false;
                break;
            }
        }

        return completed;
    }

    [System.Serializable]
    public class UltEvent : UltEvent<bool, int>
    { 
    }
}
