using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    

    [SerializeField]
    private AudioSource jump;

    [SerializeField]
    private AudioSource die;

    [SerializeField]
    private AudioSource hurt;

    [SerializeField]
    private AudioSource switchShape;

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayDie()
    {
        die.Play();
    }
    public void PlayHurt()
    {
        hurt.Play();
    }
    public void PlaySwitch()
    {
        switchShape.Play();
    }

}
