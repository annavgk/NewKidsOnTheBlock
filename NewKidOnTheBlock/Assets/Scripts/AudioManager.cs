using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField]
    private AudioSource jump;

    [SerializeField]
    private AudioSource die;

    [SerializeField]
    private AudioSource hurt;

    [SerializeField]
    private AudioSource switchShape;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        // Keeps the correct instance from being destroyed on load
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If there are multiple instances, destroy this one
            Destroy(this);
        }
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
