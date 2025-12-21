using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioSource outsideAudioSource;
    public AudioSource musicAudioSource;
    public AudioClip beep;
    public AudioClip shot;
    public AudioClip btnClick;
    public AudioClip explosion;
    public AudioClip elExplosion;
    public AudioClip spark;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip lamp;
    public AudioClip gameMusic;
    public static SoundManager Instance { get; private set; }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    private void Start()
    {
        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            audioSource.clip = lamp;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = null;
            audioSource.Play();
        }
    }

    public void AnswerSfx(bool isCorrect)
    {
        if (isCorrect) audioSource.PlayOneShot(correct);
        else audioSource.PlayOneShot(incorrect);
    }

    public void ElectricExplosion()
    {
        audioSource.PlayOneShot(elExplosion);
    }

    public void PlayShotSfx()
    {
        audioSource.PlayOneShot(shot);
    }

    public void Sparks()
    {
        audioSource.PlayOneShot(spark);
    }

    public void PlayBeepSfx()
    {
        audioSource.PlayOneShot(beep);
    }
    public void PlayExplosionSfx()
    {
        outsideAudioSource.PlayOneShot(explosion);
    }

    public void PlayButtonSfx()
    {
        audioSource.PlayOneShot(btnClick);
    }
}
