using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public bool GamePaused;

    private void Awake()
    {
        PauseMenuScreen = GameObject.Find("PauseMenuBackground"); // Finds the pause menu. Must be the background and not the PauseMenu object.
    }
    void Start()
    {
        PauseMenuScreen.SetActive(false); // Hides the pause menu
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                GameResume();
            }
            else
            {
                GamePause();
            }
        }
    }

    public void GamePause()
    {
        PauseMenuScreen.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Freeze time
        GamePaused = true; // Sets the pause flag to true
    }

    public void GameResume()
    {
        PauseMenuScreen.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume time
        GamePaused = false; // Sets the pause flag to false
    }
}
