using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayElevator : MonoBehaviour
{
    [SerializeField]
    private AudioSource _elevatorMusic;

    void Start()
    {
        _elevatorMusic = GetComponent<AudioSource>(); // Gets the AudioSource from the object
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _elevatorMusic.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _elevatorMusic.Pause();
    }
}
