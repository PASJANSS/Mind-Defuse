using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piano : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] sounds;
    int[] kotek = {8, 5, 5, 6, 3, 3, 1, 5, 8}; // 1
    int[] barka = { 5, 3, 5, 6, 5, 3, 1, 1 }; //1
    int[] potter = { 5, 8, 7, 5, 12, 10, 7, 5, 8, 7, 4 }; //1
    int[] deszcze = { 8, 11, 10, 11, 8, 8 }; //1
    int[] imperialMarch = { 8, 8, 8, 4, 11, 8, 4, 11, 8}; 
    int[] morskieOpowiesci = { 12, 7 , 12, 10, 5, 10, 8, 10, 8, 7, 5}; //1
    int[] priscilla = { 10, 10, 3, 10, 8, 3, 5, 6, 5, 6, 5}; //1
    int[] song;
    int clicked = 0;
    public Renderer lamp;
    bool isDone;
    public Image[] idImages;
    public Color[] idColors;
    List<int> randColors = new List<int>();
    //blue, red, yellow

    private void Start()
    {
        foreach (Image im in idImages) im.gameObject.SetActive(false);
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            idImages[i].gameObject.SetActive(true);
            int a = Random.Range(0, idColors.Length);
            idImages[i].color = idColors[a];
            randColors.Add(a);
        }

        switch(randColors)
        {
            case var _ when randColors.Contains(0) && randColors.Contains(1) && randColors.Contains(2):
                song = kotek;
                break;
            case var _ when randColors.Contains(0) && randColors.Contains(1):
                song = imperialMarch;
                break;
            case var _ when randColors.Contains(0) &&  randColors.Contains(2):
                song = priscilla;
                break;
            case var _ when randColors.Contains(1) && randColors.Contains(2):
                song = potter;
                break;
            case var _ when randColors.Contains(0):
                song = morskieOpowiesci;
                break;
            case var _ when randColors.Contains(1):
                song = deszcze;
                break;
            case var _ when randColors.Contains(2):
                song = barka;
                break;
        }
        
        source = transform.parent.GetComponent<AudioSource>();
    }
    public void ButtonClicked(int id)
    {
        if (isDone) return;
        source.PlayOneShot(sounds[id]);
        if (clicked+1 < song.Length)
        {
            if (song[clicked]-1 == id)
            {
                clicked++;
                BombIDGen.Instance.LightLamp(lamp, 1);
            }
            else
            {
                BombIDGen.Instance.LightLamp(lamp, 0);
                clicked = 0;
                BombIDGen.Instance.lives--;
            }
        }
        else
        {
            isDone = true;
            BombIDGen.Instance.WinLamp(lamp);
            BombIDGen.Instance.gamesDone++;
        }
    }
}
