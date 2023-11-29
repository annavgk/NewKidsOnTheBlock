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
        _dialogueText = GetComponentInChildren<TextMeshProUGUI>().gameObject; // Gets the dialogue text
    }
    void Start()
    {
        _dialogueText.SetActive(false); // Hides the dialogue text
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.layer == 7) // If the object colliding is the player character...
        {
            Debug.Log("ahh");
            _dialogueText.SetActive(true); // Shows the dialoge text
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7) // If the object colliding is the player character...
        {
            _dialogueText.SetActive(false); // Shows the dialoge text
        }
    }
}
