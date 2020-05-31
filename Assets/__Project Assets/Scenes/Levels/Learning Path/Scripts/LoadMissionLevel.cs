using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMissionLevel : MonoBehaviour
{
    public string missionSceneName;
    public bool loadScene;
    
    private void Update()
    {
        if (loadScene)
        {
            StartCoroutine(loadMission(missionSceneName));
        }
    }

    IEnumerator loadMission(string missionName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(missionName);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
