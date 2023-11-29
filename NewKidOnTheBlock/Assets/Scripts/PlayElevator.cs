using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayElevator : MonoBehaviour
{
    [SerializeField]
    private AudioSource _elevatorMusic;

    [SerializeField]
    private Transform _platform;

    [SerializeField]
    private Transform _startPoint;

    [SerializeField]
    private Transform _endPoint;

    public float Speed = 0.0002f;

    private bool _platformMovingUp; // Check to see if the platform is moving towards the end point

    private void Update()
    {
        if(_platformMovingUp)
        {
            Move(_endPoint);
        }
        else
        {
            Move(_startPoint);
        }
    }

    void Start()
    {
        _elevatorMusic = GetComponent<AudioSource>(); // Gets the AudioSource from the object
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime); // translates the platform
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("Ground")) // Makes sure the colliding object is not on layer Ground to avoid colliders interacting with each other
        {
            _elevatorMusic.Play(); // play the music
            _platformMovingUp = true; // flags the platform as moving up
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            _elevatorMusic.Pause(); // pause the music
            _platformMovingUp = false; // flags the platform as not moving up
        }

    }
}
