using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundManager : MonoBehaviour
{
    public static WaterSoundManager instance;

    [Header("Sound")]
    [SerializeField]
    private AudioClip correctSound;

    [SerializeField]
    private AudioClip incorrectSound;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectSound()
    {
        audioSource.clip = correctSound;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void PlayIncorrectSound()
    {
        audioSource.clip = incorrectSound;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }
}
