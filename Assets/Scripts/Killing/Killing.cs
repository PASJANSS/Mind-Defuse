using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killing : MonoBehaviour
{
    public List<Sprite> gostki = new List<Sprite>();
    public Image image;
    public Image timer;
    bool kill;
    int correctAnswers;
    public Renderer lamp;
    bool isDone;
    [HideInInspector] public bool start;
    public ParticleSystem blood;
    float time;
    public float startTime;

    private void Start()
    {
        time = startTime;
    }

    private void Update()
    {
        if (isDone || !start) return;
        timer.fillAmount = time / startTime;
        time -= Time.deltaTime;
        if(time <= 0)
        {
            time = startTime;
            BombIDGen.Instance.lives--;
            GenerateGuy();
            BombIDGen.Instance.LightLamp(lamp, 0);
        }
    }

    public void Kill(bool isKilling)
    {
        if (isDone || !start)
        {
            image.color = new Vector4(255, 255, 255, 0);
            return;
        }
        if (isKilling)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                blood.transform.position = hit.point;
            }
            blood.Play();
            SoundManager.Instance.PlayShotSfx();
        }

        if(isKilling == kill)
        {
            BombIDGen.Instance.LightLamp(lamp, 1);
            correctAnswers++;
            if (correctAnswers >= 3)
            {
                isDone = true;
                BombIDGen.Instance.gamesDone++;
                BombIDGen.Instance.WinLamp(lamp);
            }
            GenerateGuy();
        }
        else
        {
            BombIDGen.Instance.lives--;
            GenerateGuy();
            BombIDGen.Instance.LightLamp(lamp, 0);
        }
        time = startTime;
    }

    public void GenerateGuy()
    {
        if (isDone) return;
        Sprite sprite = gostki[Random.Range(0, gostki.Count)];
        gostki.Remove(sprite);
        image.sprite = sprite;
        if (sprite.name[0] == 'k') kill = true;
        else kill = false;
    }
}
