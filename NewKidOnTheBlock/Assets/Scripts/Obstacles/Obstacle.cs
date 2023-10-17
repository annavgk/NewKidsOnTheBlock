using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    public UnityEvent PlayerHit;
  

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("player hit");
            GameManager.Instance.ChangeHealth(damage);
            PlayerHit.Invoke();
        }
    }
}
