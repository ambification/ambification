using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckValidMission : MonoBehaviour
{
    public bool unlockedMission;
    public bool nextMission;
    public GameObject arrowMark;
    public GameObject exclamationMark;

    private void Update()
    {
        if (unlockedMission)
        {
            exclamationMark.SetActive(false);
        }
        else
        {
            exclamationMark.SetActive(true);
        }
        
        if (nextMission)
        {
            arrowMark.SetActive(true);
        }
        else
        {
            arrowMark.SetActive(false);
        }
    }
}
