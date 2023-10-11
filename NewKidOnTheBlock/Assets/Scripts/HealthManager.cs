using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives = 3;
    public UnityEvent onPlayerHit;
    public UnityEvent onPlayerDeath;
    private GameObject _player;

    void Start()
    {
        _player = FindObjectOfType<PlayerController_a>().gameObject;
        currentLives = maxLives;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        currentLives -= damage;
        Debug.Log(currentLives + " lives");
        onPlayerHit.Invoke();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death logic here
        onPlayerDeath.Invoke();
        Destroy(_player);
        Debug.Log("you dead");
        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad()
    {
        Debug.Log("Scene reloading");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
