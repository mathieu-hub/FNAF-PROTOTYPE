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
    [SerializeField]
    private bool timeActive = true;

    [Header("NIGHT")]
    public int night;
    public Text nightText;

    [Header("TRANSITION")]
    public Animator animator;
    public bool canFade = false;


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
        if (timeActive)
        {
            timer += Time.deltaTime; //Clock System
        }

        timeText.text = uiTimer.ToString() + "AM"; //Affichage textuel de la valeur uiTimer dans la textBox
        nightText.text = "Night " + night.ToString(); //Affichage textuel de la valeur night dans la textBox
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
            canFade = true;
            midnightIsPassed = false;
            timeActive = false;

            if (canFade)
            {
                animator.SetBool("fadeOut", true);
                canFade = false;
            }
            animator.SetBool("fadeOut", true);
            StartCoroutine(NightTransition());
        }
    }

    IEnumerator NightTransition()
    {
        yield return new WaitForSeconds(2f);
        night++;
        timer = timeStart;
        animator.SetBool("fadeOut", false);
    }
}

