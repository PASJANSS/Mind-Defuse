using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BombIDGen : MonoBehaviour
{
    public static BombIDGen Instance { get; private set; }
    [HideInInspector] public int batteriesCombination;
    [HideInInspector] public int lives;
    [HideInInspector] public int gamesDone;
    [HideInInspector] public int cableColor;
    [HideInInspector] public string id;
    [HideInInspector] public int cutCable = 10;
    [HideInInspector] public string seconds;
    [HideInInspector] public string minutes;
    [HideInInspector] public float time;
    [HideInInspector] public int startLives;
    public int modules = 10;
    public Vector3[] batteriesPositions;
    public Vector3[] batteriesRotations;
    public Vector3[] timerPositions;
    public Vector3[] timerRotations;
    public Vector3[] idPositions;
    public Vector3[] idRotations;
    public Color[] cableColors;
    public Material cableMaterial;
    public Transform[] batteries;
    public Transform batteriesStation;
    public TextMeshProUGUI idNumber;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText2;
    public Transform idStation;
    public GameObject background;
    public GameObject endGameController;
    public Transform timer;
    int[] batRots = { 90, 270 };
    public int idLength;
    public Color redLampMat;
    public Color greenLampMat;
    public Color defLampMat;
    public ParticleSystem explosion;
    Renderer currentLamp;
    bool isTimeGoing = true;
    int lastSec;
    int min;
    int sec;
    char[] characters = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z',
        'X', 'C', 'V', 'B', 'N', 'M', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '1', '2', '3', '4', '5', '6', '7',
        '8', '9', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Awake()
    {
        lives = PlayerPrefs.GetInt("Lives");
        modules = PlayerPrefs.GetInt("Modules");
        startLives = lives;
        time = PlayerPrefs.GetInt("Time") * 10;
        GetComponent<AudioSource>().volume = (float)PlayerPrefs.GetInt("Volume") / 10;
        GetComponent<SoundManager>().outsideAudioSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10;
        GetComponent<SoundManager>().musicAudioSource.clip = GetComponent<SoundManager>().gameMusic;
        GetComponent<SoundManager>().musicAudioSource.volume = (float)PlayerPrefs.GetInt("Volume") / 10  * PlayerPrefs.GetInt("Music");
        GetComponent<SoundManager>().musicAudioSource.Play();
        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //timer pos

        int y = Random.Range(0, timerPositions.Length);
        timer.localPosition = timerPositions[y];
        timer.localRotation = Quaternion.Euler(timerRotations[y]);
        GameObject scdTimer = Instantiate(timer.gameObject, transform);
        scdTimer.transform.localPosition = new Vector3(timerPositions[y].x, timerPositions[y].y, -timerPositions[y].z);
        scdTimer.transform.localRotation = Quaternion.Euler(270, 180, 0);
        timerText2 = scdTimer.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        //cable materials

        //0 - red
        //1 - black
        //2 - blue
        //3 - green
        int b = Random.Range(0, cableColors.Length);
        cableColor = b;
        cableMaterial.color = cableColors[b];

        //batteries

        //1 - ten sam kierunek
        //0 odwrotny kierunek
        int x = batRots[Random.Range(0, 2)];
        if (x == 90) batteriesCombination = 1;
        else batteriesCombination = 0;
        batteries[1].localRotation = Quaternion.Euler(x, 90, 180);
        int a = Random.Range(0, batteriesPositions.Length);
        batteriesStation.localPosition = batteriesPositions[a];
        batteriesStation.localRotation = Quaternion.Euler(batteriesRotations[a]);

        //id number
        for (int i = 0; i < idLength; i++)
        {
            id += characters[Random.Range(0, characters.Length)];
        }
        idNumber.text = id;
        a = Random.Range(0, idPositions.Length);
        idStation.localPosition = idPositions[a];
        idStation.localRotation = Quaternion.Euler(idRotations[a]);
    }

    public void LightLamp(Renderer lamp, int isGreen)
    {
        SoundManager.Instance.AnswerSfx(isGreen != 0);
        lamp.transform.GetChild(0).gameObject.SetActive(true);
        if (isGreen == 1)
        {
            lamp.transform.GetChild(0).GetComponent<Light>().color = greenLampMat;
            lamp.GetComponent<Renderer>().material.color = greenLampMat;
        }
        else
        {
            lamp.transform.GetChild(0).GetComponent<Light>().color = redLampMat;
            lamp.GetComponent<Renderer>().material.color = redLampMat;
        }
        currentLamp = lamp;
        Invoke("Resett", .5f);
    }

    void WinGame()
    {
        isTimeGoing = false;
        Camera.main.GetComponent<Shower>().ShowGameInfo("YOU WON!", gamesDone, lives, minutes, seconds);
    }

    private void Update()
    {
        if (gamesDone >= modules) WinGame();
        if (lives <= 0 || time <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SoundManager.Instance.PlayExplosionSfx();
            explosion.Play();
            Camera.main.GetComponent<Shower>().ShowGameInfo("YOU LOST!", gamesDone, lives, minutes, seconds);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            if (!isTimeGoing) return;
            time -= Time.deltaTime;
            min = (((int)Mathf.Round(time)) / 60);
            sec = (((int)Mathf.Round(time)) % 60);
            if (min < 10) minutes = "0" + min;
            else minutes = min.ToString();
            if (sec < 10) seconds = "0" + sec;
            else seconds = sec.ToString();
            if (time <= 0) lives = 0;
            timerText.text = minutes + ":" + seconds;
            timerText2.text = minutes + ":" + seconds;
            if(lastSec != sec)
            {
                lastSec = sec;
                SoundManager.Instance.PlayBeepSfx();
            }
         }
    }


    public void WinLamp(Renderer lamp)
    {
        StartCoroutine(Winn(lamp));
    }

    IEnumerator Winn(Renderer lamp)
    {
        yield return new WaitForSeconds(.55f);
        SoundManager.Instance.AnswerSfx(true);
        lamp.transform.GetChild(0).gameObject.SetActive(true);
        lamp.transform.GetChild(0).GetComponent<Light>().color = greenLampMat;
        lamp.GetComponent<Renderer>().material.color = greenLampMat;
    }
           
    private void Resett()
    {
        currentLamp.transform.GetChild(0).gameObject.SetActive(false);
        currentLamp.GetComponent<Renderer>().material.color = defLampMat;
    }
}
