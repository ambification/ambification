﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MenuScreen");
    }

    public RoundData GetCourrentRoundData()
    {
        return allRoundData[0];
    }
}