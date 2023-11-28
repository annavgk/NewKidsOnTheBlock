using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject _dialogueText;

    private void Awake()
    {
        _dialogueText = GameObject.Find("DialogueText"); // Gets the dialogue text
    }
    void Start()
    {
        _dialogueText.SetActive(false); // Hides the dialogue text
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player") // If the object colliding is the player character...
        {
            _dialogueText.SetActive(true); // Shows the dialoge text
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") // If the object colliding is the player character...
        {
            _dialogueText.SetActive(false); // Shows the dialoge text
        }
    }
}
