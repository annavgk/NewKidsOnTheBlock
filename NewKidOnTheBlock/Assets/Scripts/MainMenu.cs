using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    private bool _controlsOpen = false;

    [SerializeField]
    private GameObject _controls;

    [SerializeField]
    private GameObject _startButton;

    private void Awake()
    {
        _controls = GameObject.Find("Controls"); // Finds the Controls screen

        _startButton = GameObject.Find("ResumeButton"); // Finds the Start Button
    }
    void Start()
    {
        _controls.SetActive(false); // Hides the controls screen

        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && _controlsOpen == true) // After pressing escape, if the controls screen is open...
        {
            {
                _controls.SetActive(false); // Hides the controls screen
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject); // If anyone accidentally clicks the screen, the selection will automatically return to the Start button.
        }
    }

    public void OnStartPress()
    {
        SceneManager.LoadScene("Level1"); // Loads level 1
    }

    public void OnControlsPress()
    {
        _controls.SetActive(true); // Shows the controls screen
        _controlsOpen = true; // Flags the controls screen as being open
    }

    public void OnQuitPress()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Quits the game
    }   
}
