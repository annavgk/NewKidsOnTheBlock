using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pauseMenuScreen;

    private bool _gamePaused;

    [Header("Scripts to Deactivate on Pause")] // Deactivating these scripts will keep the player and other objects from moving while the game is paused.

    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private Obstacle _obstacleScript;

    private void Awake()
    {
        _pauseMenuScreen = GameObject.Find("PauseMenuBackground"); // Finds the pause menu. Must be the background and not the PauseMenu object.
    }
    void Start()
    {
        _pauseMenuScreen.SetActive(false); // Hides the pause menu
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_gamePaused)
            {
                GameResume();
            }
            else
            {
                GamePause();
            }
        }
    }

    #region Pause/Resume functions
    public void GamePause()
    {
        _pauseMenuScreen.SetActive(true); // Show the pause menu

        Time.timeScale = 0f; // Freeze time

        _playerController.enabled = false; // Deactivate the PlayerController script

        if (_obstacleScript != null)
            _obstacleScript.enabled = false; // Deactivate the Obstacle script if it exists in the scene

        _gamePaused = true; // Sets the pause flag to true
    }

    public void GameResume()
    {
        _pauseMenuScreen.SetActive(false); // Hide the pause menu

        Time.timeScale = 1f; // Resume time

        _playerController.enabled = true; // Activate the PlayerController script

        if(_obstacleScript != null)
            _obstacleScript.enabled = true; // Activate the Obstacle script if it exists in the scene

        _gamePaused = false; // Sets the pause flag to false
    }
    #endregion

    #region Button Actions

    public void OnResumePress()
    {

    }

    public void OnMainMenuPress()
    {
        //SceneManager.LoadScene("MainMenu");

        // I can't find a main menu so I'm assuming we need to add it still.
    }

    #endregion
}
