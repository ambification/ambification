using d4160.GameFramework;
using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceHelper : MonoBehaviour
{
    public void SetLevelIndexByAdvice(int index)
    {
        GameManager.Instance.GetLevelLauncher<LoadingScreenLauncher>(0).SetLevelIndexByAdvice(index);
    }
}
