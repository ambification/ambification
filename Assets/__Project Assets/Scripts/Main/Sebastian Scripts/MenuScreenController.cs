using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    /// <summary>
    /// Loads the "Game Scene", this event is enabled by OnClick event in button component
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
