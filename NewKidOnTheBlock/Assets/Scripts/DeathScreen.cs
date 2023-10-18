using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    [SerializeField] private AudioSource theme;
    [SerializeField] private AudioSource start;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine("Go");
        }
    }
    IEnumerator Go()
    {
        start.Play();
        yield return new WaitForSeconds(.287f);
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene("Level1");
    }
}
