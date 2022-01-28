using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Manager : MonoBehaviour
{
    [SerializeField] List<AudioClip> bgMusics;
    AudioSource audioSource;
    int currentIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgMusics[currentIndex];
        if(audioSource.isPlaying == false)
            audioSource.Play();
    }

    public void PlayNextMusic()
    {
        audioSource.Pause();
        currentIndex++;

        if (currentIndex >= bgMusics.Count)
            return;

        audioSource.clip = bgMusics[currentIndex];
        audioSource.Play();
    }
}
