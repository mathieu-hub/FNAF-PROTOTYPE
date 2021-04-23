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
    public Text textBox;

    [Header("NIGHT")]
    public int night = 1;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = timeStart;
        uiTimer = 12;
        textBox.text = uiTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //Clock System
        textBox.text = uiTimer.ToString(); //Affichage textuel de la valeur uiTimer dans la textBox
        TimePassing();
    }

    void TimePassing()
    {
        if(timer == 90)
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
    }
}
