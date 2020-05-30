using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAchievementsLevel : MonoBehaviour
{
    public string achievementsScene;
    
    public void LoadAchievments()
    {
        StartCoroutine(loadAchievments());
    }

    IEnumerator loadAchievments()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(achievementsScene);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
