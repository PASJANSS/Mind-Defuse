using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutManager : MonoBehaviour
{
    public GameObject cutCable;
    int neededCable;
    public Renderer lamp;
    bool isDone;
    int val;

    private void Start()
    {
        //0 - red
        //1 - black
        //2 - blue
        //3 - green
        if (BombIDGen.Instance.cableColor == 3 || BombIDGen.Instance.cableColor == 1) 
        {
            neededCable = 2;
            val++;
        }
        if(BombIDGen.Instance.cableColor == 0 || BombIDGen.Instance.cableColor == 2)
        {
            neededCable = 1;
            val++;
        }
        int sum = 0;
        foreach (char z in BombIDGen.Instance.id)
        {
            if (char.IsNumber(z)) sum += z - '0';
        }
        if(sum > 25)
        {
            neededCable = 0;
            val++;
        }
        if (val > 1) neededCable = 3;
    }

    public void CableCllicked(int cableId, GameObject cable, ParticleSystem correct, ParticleSystem incorrect)
    {
        if (isDone) return;
        cable.GetComponent<Animator>().SetTrigger("cut");
        BombIDGen.Instance.cutCable = cableId;
        
        if (neededCable == cableId)
        {
            SoundManager.Instance.Sparks();
            correct.gameObject.SetActive(true);
            correct.Play();
            BombIDGen.Instance.WinLamp(lamp);
            BombIDGen.Instance.gamesDone++;
            isDone = true;
        }
        else 
        {
            SoundManager.Instance.ElectricExplosion();
            StartCoroutine(DestroyIt(incorrect.gameObject));
            incorrect.gameObject.SetActive(true);
            incorrect.Play();
            BombIDGen.Instance.LightLamp(lamp, 0);
            BombIDGen.Instance.lives--;
        }
    }

    IEnumerator DestroyIt(GameObject sys)
    {
        yield return new WaitForSeconds(0.5f);
        sys.SetActive(false);
    }
}
