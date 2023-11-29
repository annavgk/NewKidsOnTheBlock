using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Piano : MonoBehaviour
{
    public UnityEvent Activate;

    [SerializeField] private BoxCollider2D _triggerBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hi");

        Activate.Invoke();

    }
}
