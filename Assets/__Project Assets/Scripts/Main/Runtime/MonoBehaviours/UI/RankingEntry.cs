using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingEntry : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;

    public void Update(string playerName, string score)
    {
        playerNameText.text = playerName;
        scoreText.text = score;
    }
}
