using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    private AnswerData answerData;
    private QuizGameController _gameController;

    private void Start()
    {
        _gameController = FindObjectOfType<QuizGameController>();
    }

    public void SetUp(AnswerData answerdata)
    {
        answerData = answerdata;
        answerText.text = answerData.answerText;
    }

    public void HandleClick()
    {
        _gameController.AnsweButtonClicked(answerData.isCorrect);
    }
}
