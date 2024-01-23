using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSoundManager : MonoBehaviour
{
    public static AirSoundManager instance;

    [Header("Sound")]
    [SerializeField]
    private AudioClip correctSound;

    [SerializeField]
    private AudioClip incorrectSound;

    private AudioSource audioSource;

    [SerializeField]
    private AudioSource backgroundAudioSource;

    [SerializeField]
    private List<AudioClip> carSoundList;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(backSoundPlay());
    }

    public void PlayCorrectSound()
    {
        audioSource.clip = correctSound;
        audioSource.volume = 0.7f;
        audioSource.Play();
    }

    public void PlayIncorrectSound()
    {
        audioSource.clip = incorrectSound;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }

    IEnumerator backSoundPlay()
    {
        while (true)
        {
            int idx = Random.Range(0, carSoundList.Count);
            backgroundAudioSource.clip = carSoundList[idx];
            backgroundAudioSource.Play();
            yield return new WaitForSeconds(Random.Range(5f, 7f));
        }
    }
}
