using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }

    }

    [SerializeField] private int _maxHealth = 4;
    private int _currentHealth;
    public int CurrentHealth { get { return _currentHealth; } }

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        _currentHealth = _maxHealth;
    }
    void Start()
    {
        
    }

    public void ChangeHealth(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        SceneReloader();
        
    }

    private void SceneReloader()
    {
        if(_currentHealth > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(_currentHealth <= 0)
        {
            _currentHealth = _maxHealth;
            SceneManager.LoadScene("Level1");
        }
    }

    public void NextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
}
