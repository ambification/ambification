using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCharacter : MonoBehaviour
{
    public LoadMissionLevel loadMissionLevelScript;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player Detected!");
            loadMissionLevelScript.loadScene = true;
        }
    }
}
