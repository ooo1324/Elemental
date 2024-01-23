using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSoundManager : MonoBehaviour
{
    public static EarthSoundManager instance;

    [Header("Sound")]
    [SerializeField]
    private AudioClip correctSound;

    [SerializeField]
    private AudioClip incorrectSound;

    [SerializeField]
    private AudioClip throwSound;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectSound()
    {
        audioSource.clip = correctSound;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }

    public void PlayIncorrectSound()
    {
        audioSource.clip = incorrectSound;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }

    public void PlayThrowSound()
    {
        audioSource.clip = throwSound;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
