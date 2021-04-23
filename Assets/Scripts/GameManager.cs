using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("CAMERA MANAGER")]
    public CamManager CameraManager;

    [Header("TIME")]
    public float timeStart = 0;
    public float timer;
    public int uiTimer;
    public Text timeText;
    [SerializeField]
    private bool midnightIsPassed = false;

    [Header("NIGHT")]
    public int night;
    public Text nightText;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = timeStart;
        uiTimer = 12;
        timeText.text = uiTimer.ToString();
        night = 1;
        nightText.text = night.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime; //Clock System
        timeText.text = uiTimer.ToString() + "AM"; //Affichage textuel de la valeur uiTimer dans la textBox
        nightText.text = "Night " + night.ToString();
        TimePassing();
        EndNight();
    }

    void TimePassing()
    {
        if(timer >= 90)
        {
            timer = timeStart;
            if (uiTimer == 12)
            {
                uiTimer = 1;
            }
            else
            {
                uiTimer += 1;
            }
        }

        if(uiTimer == 1)
        {
            midnightIsPassed = true;
        }
    }

    void EndNight()
    {
        if (uiTimer >= 6 && midnightIsPassed)
        {
            night++;
            midnightIsPassed = false;
        }
    }
}
