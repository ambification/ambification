﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController1 : MonoBehaviour
{
    public SimpleObjectPool answerButtonObjectPool;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private DataController _dataController;
    private RoundData _currentRoundData;
    private QuestionData[] _questionPool;
    private bool _isRoundActive;
    private float _timeRemaining;
    private int _questionIndex;
    private int _playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private void Start()
    {
        _dataController = FindObjectOfType<DataController>();
        _currentRoundData = _dataController.GetCourrentRoundData();
        _timeRemaining = _currentRoundData.timeLimitInSeconds;

        _playerScore = 0;
        _questionIndex = 0;
        
        ShowQuestion();

        _isRoundActive = true;
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = _questionPool[_questionIndex];
        questionText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);
        }
    }

    public void AnsweButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            _playerScore += _currentRoundData.pointAddedForCorrectAnswer;
            scoreText.text = "Score: " + _playerScore.ToString();
        }

        if (_questionPool.Length > _questionIndex + 1)
        {
            _questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        _isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonGameObjects.RemoveAll(0);
        }
    }
}
