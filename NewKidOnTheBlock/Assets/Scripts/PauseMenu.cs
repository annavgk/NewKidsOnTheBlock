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

    [SerializeField]
    private GameObject _resumeButton;

    [SerializeField]
    private GameObject _mainMenuButton;

    private void Awake()
    {
        _pauseMenuScreen = GameObject.Find("PauseMenuBackground"); // Finds the pause menu. Must be the background and not the PauseMenu object.

        _player = GameObject.Find("Player"); // Finds the player

        _resumeButton = GameObject.Find("ResumeButton"); // Finds the Resume Button

        _mainMenuButton = GameObject.Find("MainMenuButton"); // Finds the Main Menu Button
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
            if(!_gamePaused)
            {
                GamePause();
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventSystem.current.SetSelectedGameObject(_resumeButton); // If Up Arrow is pressed, select the Resume button.
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventSystem.current.SetSelectedGameObject(_mainMenuButton); // If Down Arrow is pressed, select the Main Menu button.
        }
    }

    #region Pause/Resume functions
    public void GamePause()
    {
        _gamePaused = true; // Sets the pause flag to true

        OpenMenu();

        Time.timeScale = 0f; // Freeze time

    }

    public void GameResume()
    {

        _gamePaused = false; // Sets the pause flag to false

        CloseMenu();

        Time.timeScale = 1f; // Resume time
    }

    private void OpenMenu()
    {
        _pauseMenuScreen.SetActive(true); // Show the pause menu
        EventSystem.current.SetSelectedGameObject(_resumeButton); // Sets the selected object as the Resume button
    }

    private void CloseMenu()
    {
        _pauseMenuScreen.SetActive(false); // Hide the pause menu
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
