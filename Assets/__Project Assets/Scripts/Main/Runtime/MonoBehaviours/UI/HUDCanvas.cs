using System.Collections;
using System.Collections.Generic;
using d4160.Core;
using d4160.GameFoundation;
using d4160.GameFramework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : CanvasBase, IMultipleStatUpgradeable
{
    public QuestBehaviour quest;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missionTitle;
    public TaskUI[] tasksUI;

    private float _time;
    private bool _timerActived;

    public string TimeString => $"Time: {((int)_time / 60).ToZeroFormattedString()}:{((int)_time % 60).ToZeroFormattedString()}";

    protected override void Start()
    {
        base.Start();

        _timerActived = true;

        missionTitle.text = quest.SelectedQuest.Name;

        for (int i = 0; i < tasksUI.Length; i++)
        {
            if (i < quest.SelectedQuest.tasks.Count)
            {
                tasksUI[i].UpdateName(quest.GetSelectedTask(i).name);
                tasksUI[i].UpdateCompletedMarker(quest.DoneTaskTracking[i]);
                tasksUI[i].gameObject.SetActive(true);
            }
            else
            {
                tasksUI[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (!_timerActived) return;

        _time += Time.deltaTime;

        timeText.text = TimeString;
    }

    public void SetTimerActive(bool active)
    {
        _timerActived = active;
    }

    public void UpdateStat(int index, float value)
    {
        scoreText.text = $"Score: {(int)value}";
    }

    public void UpdateTaskValue(bool completedState, int index)
    {
        tasksUI[index].UpdateCompletedMarker(completedState);
    }
}
