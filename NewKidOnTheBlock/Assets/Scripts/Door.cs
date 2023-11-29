using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite _openDoor;
    [SerializeField] private Sprite _closeDoor;
    private SpriteRenderer _renderer;
    [SerializeField] bool _open;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if( _open )
        {
            _renderer.sprite = _openDoor;
        }
        else
        {
            _renderer.sprite = _closeDoor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_open && collision.gameObject.layer == 7)
        {
            Debug.Log("you win");
            GameManager.Instance.NextScene();
        }
        
    }

    public void Activate()
    {
        _open = !_open;
        if (_open)
        {
            _renderer.sprite = _openDoor;
        }
        else
        {
            _renderer.sprite = _closeDoor;
        }
    }


}
