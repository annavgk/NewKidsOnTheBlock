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
        if (other.gameObject.name == "NewPlayer") // If the object colliding is the player character...
        {
            _elevatorMusic.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "NewPlayer") // If the object leaving the collider is the player character...
        {
            _elevatorMusic.Pause();
        }
    }
}
