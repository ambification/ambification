using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public GameObject completedMarker;

    public void UpdateName(string name)
    {
        if (nameText)
            nameText.text = name;
    }

    public void UpdateCompletedMarker(bool completed)
    {
        completedMarker?.SetActive(completed);
    }
}
