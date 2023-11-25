using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pauseMenuScreen;

    private bool _gamePaused;

    [SerializeField]
    private GameObject _player;

    [Header("First Selected Options")]

    [SerializeField] 
    private GameObject _resumeFirst;

    [SerializeField]
    private GameObject _mainMenuFirst;

    private void Awake()
    {
        _pauseMenuScreen = GameObject.Find("PauseMenuBackground"); // Finds the pause menu. Must be the background and not the PauseMenu object.

        _player = GameObject.Find("Player"); // Finds the player
    }
    void Start()
    {
        _pauseMenuScreen.SetActive(false); // Hides the pause menu
    }

    void Update()
    {

        if(_gamePaused)
        {
            if (_player != null)
                _player.SetActive(false); // Deactivate the Player object if it exists in the scene. Keeps the player character from recieving any inputs while the game is paused.
        }
        else if(!_gamePaused)
        {
            if (_player != null)
                _player.SetActive(true); // Activate the Player object if it exists in the scene
        }

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
        _gamePaused = true; // Sets the pause flag to true

        _pauseMenuScreen.SetActive(true); // Show the pause menu

        Time.timeScale = 0f; // Freeze time

    }

    public void GameResume()
    {

        _gamePaused = false; // Sets the pause flag to false

        _pauseMenuScreen.SetActive(false); // Hide the pause menu

        Time.timeScale = 1f; // Resume time
    }
    #endregion

    #region Button Actions

    public void OnResumePress()
    {
        GameResume(); // Resumes the game when the Resume button is pressed.
    }

    public void OnMainMenuPress()
    {
        //SceneManager.LoadScene("MainMenu");

        // I can't find a main menu so I'm assuming we need to add it still. Loads the Main Menu when the Main Menu button is pressed.
    }

    #endregion
}
