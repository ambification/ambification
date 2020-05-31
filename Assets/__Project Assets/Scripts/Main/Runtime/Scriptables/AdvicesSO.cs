using d4160.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AdvicesSO : ScriptableObject
{
    public Advice[] advices;

    public string GetAdviceTitle(int idx)
    {
        if (advices.IsValidIndex(idx))
        {
            return advices[idx].adviceTitle;
        }

        return string.Empty;
    }

    public string GetAdvice(int idx)
    {
        if (advices.IsValidIndex(idx))
        {
            return advices[idx].adviceTexts.Random();
        }

        return string.Empty;
    }

    public Sprite GetAdviceSprite(int idx)
    {
        if (advices.IsValidIndex(idx))
        {
            return advices[idx].adviceSprites.Random();
        }

        return null;
    }
}


[System.Serializable]
public struct Advice
{
    public string adviceTitle;
    [TextArea]
    public string[] adviceTexts;
    public Sprite[] adviceSprites;
}