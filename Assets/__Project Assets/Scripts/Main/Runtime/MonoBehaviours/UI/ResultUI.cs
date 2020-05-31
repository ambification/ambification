using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI missionScore;
    public TextMeshProUGUI testScore;
    public TextMeshProUGUI timeText;

    public void SetPlayerScore(int score)
    {
        playerScore.text = score.ToString();
    }

    public void SetMissionScore(int score)
    {
        missionScore.text = score.ToString();
    }

    public void SetTestScore(int score)
    {
        testScore.text = score.ToString();
    }

    public void SetTime(string timeString)
    {
        timeText.text = timeString;
    }
}
