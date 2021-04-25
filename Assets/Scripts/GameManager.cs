﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("CAMERA MANAGER")]
    public CamManager CameraManager;

    [Header("POWER MANAGER")]
    public PowerManager PowerManager;

    [Header("TIME")]
    public float timeStart = 0;
    public float timer;
    public int uiTimer;
    public Text timeText;
    [SerializeField]
    private bool midnightIsPassed = false;
    [SerializeField]
    private bool timeActive = true;

    [Header("NIGHT")]
    public int night;
    public Text nightText;

    [Header("TRANSITION")]
    public Animator animator;
    public Animator animator2;
    public Text nightSwitchText;
    public GameObject nightSwich;

    [Header("TABLETTE")]
    public TabletteController tabletteController;


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
        nightSwitchText.text = night.ToString();
        nightSwich.SetActive(false);
    }

    void Update()
    {
        if (timeActive)
        {
            timer += Time.deltaTime; //Clock System
        }

        timeText.text = uiTimer.ToString() + "AM"; //Affichage textuel de la valeur uiTimer dans la textBox
        nightText.text = "Night " + night.ToString(); //Affichage textuel de la valeur night dans la textBox
        nightSwitchText.text = "Night " + night.ToString();
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

    void EndNight() //Player Survives The Night 
    {
        if (uiTimer >= 6 && midnightIsPassed)
        {
            midnightIsPassed = false;
            timeActive = false;
            nightSwich.SetActive(true);
            animator.SetBool("fadeOut", true);
            StartCoroutine(NightTransition());
        }
    }

    IEnumerator NightTransition()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("fadeOut", false);
        animator.SetBool("blackScreenLoop", true);
        animator2.SetBool("fadeText", true);
        yield return new WaitForSeconds(0.1f);
        animator2.SetBool("fadeText", false);
        animator2.SetBool("displayText", true);
        yield return new WaitForSeconds(2f);
        night++;
        timer = timeStart;
        uiTimer = 12;

        if (tabletteController.openTablette == true)
        {
            tabletteController.OpenCloseTablette();
        }

        yield return new WaitForSeconds(2f);
        timeActive = true;
        animator2.SetBool("displayText", false);
        animator.SetBool("blackScreenLoop", false);
    }
}

