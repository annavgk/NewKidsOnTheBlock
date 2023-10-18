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
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "YouWin" || SceneManager.GetActiveScene().name == "YouDie")
        {
            Destroy(this.gameObject);
        }
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
            StartCoroutine("Die");
        }
        else if(_currentHealth <= 0)
        {
            _currentHealth = _maxHealth;
            SceneManager.LoadScene("YouDie");
        }
    }

    public void NextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
    IEnumerator Die()
    {
        Time.timeScale = 0;
        AudioManager.Instance.PlayHurt();
        yield return new WaitForSecondsRealtime(1.097f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
