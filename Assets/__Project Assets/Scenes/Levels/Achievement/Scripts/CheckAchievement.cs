using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAchievement : MonoBehaviour
{
    public GameObject activeAch;
    public GameObject blackAch;
    
    public bool achievementUnlocked;

    private void Update()
    {
        if (achievementUnlocked)
        {
            activeAch.SetActive(true);
            blackAch.SetActive(false);
        }
        else
        {
            activeAch.SetActive(false);
            blackAch.SetActive(true);
        }
    }
}
