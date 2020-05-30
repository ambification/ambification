using System;
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
    private QuestionData[] _quesionPool;
    private bool _isRoundActive;
    private float _timeRemaining;
    private int _questionIndex;
    private int _playerScore;
    private List<GameObject> answeButtonGameObjects = new List<GameObject>();

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
        QuestionData questionData = _quesionPool[_questionIndex];
        questionText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            
        }
    }
}
