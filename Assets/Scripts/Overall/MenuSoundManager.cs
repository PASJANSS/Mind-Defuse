using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    public static MenuSoundManager Instance { get; set; }
    AudioSource source;
    public AudioClip click;
    public AudioClip hover;
    public AudioClip nextPage;
    public AudioClip previousPage;
    public AudioClip lamp;

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
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void PlayClickSfx()
    {
        source.PlayOneShot(click);
    }
    public void PlayHoverSfx()
    {
        source.PlayOneShot(hover);
    }
    public void PlayNextPageSfx()
    {
        source.PlayOneShot(nextPage);
    }
    public void PlayPreviousPageSfx()
    {
        source.PlayOneShot(previousPage);
    }

}
