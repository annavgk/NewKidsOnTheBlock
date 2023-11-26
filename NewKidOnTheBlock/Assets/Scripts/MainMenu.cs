using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool _controlsOpen;

    [SerializeField]
    private GameObject _controls;

    [SerializeField]
    private GameObject _startButton;

    void Start()
    {
        _controls = GameObject.Find("Controls"); // Finds the Controls screen

        _startButton = GameObject.Find("ResumeButton"); // Finds the Start Button

    }

    void Update()
    {
        
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
        Debug.Log("Quitting game..."); // Quits the game
    }
}
