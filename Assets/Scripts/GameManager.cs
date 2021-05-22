using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("RÉFÉRENCES")]
    public CamManager CameraManager;
    public PowerManager PowerManager;
    public DoorController doorControllerLeft;
    public DoorController doorControllerRight;
    public TabletteController tabletteController;

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

    [Header("GAME OVER")]
    public GameObject background;
    public GameObject buttonRestart;    


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

        ActivateEnemmies();
    }

    void ActivateEnemmies()
    {
        if (night == 1)
        {
            if (uiTimer == 12 && timer >= 40)
            {
                EnemyManager.Instance.bonnieCanMove = true;
            }

            if (uiTimer == 1 && timer >= 25)
            {
                EnemyManager.Instance.chiccaCanMove = true;
            }
        }

        if (night == 2)
        {
            if (uiTimer == 12 && timer >= 10)
            {
                EnemyManager.Instance.bonnieCanMove = true;
            }

            if (uiTimer == 1)
            {
                EnemyManager.Instance.chiccaCanMove = true;
            }

            if (uiTimer == 4 && timer >= 50)
            {
                EnemyManager.Instance.freddyCanMove = true;
            }
        }

        if (night == 3)
        {
            if (uiTimer == 12 && timer >= 5)
            {
                EnemyManager.Instance.bonnieCanMove = true;
            }

            if (uiTimer == 1)
            {
                EnemyManager.Instance.chiccaCanMove = true;
            }

            if (uiTimer == 3)
            {
                EnemyManager.Instance.freddyCanMove = true;
            }
        }

        if (night == 4)
        {
            if (uiTimer == 12 && timer >= 5)
            {
                EnemyManager.Instance.bonnieCanMove = true;
            }

            if (uiTimer == 12 && timer >= 30)
            {
                EnemyManager.Instance.chiccaCanMove = true;
            }

            if (uiTimer == 2)
            {
                EnemyManager.Instance.freddyCanMove = true;
            }
        }

        if (night == 5)
        {
            if (uiTimer == 12 && timer >= 5)
            {
                EnemyManager.Instance.bonnieCanMove = true;
            }

            if (uiTimer == 12 && timer >= 30)
            {
                EnemyManager.Instance.chiccaCanMove = true;
            }

            if (uiTimer == 1)
            {
                EnemyManager.Instance.freddyCanMove = true;
            }
        }
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
            PowerManager.powerCanSink = false;
            nightSwich.SetActive(true);
            animator.SetBool("fadeOut", true);
            EnemyManager.Instance.Initialisation();
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
        EnemyManager.Instance.Initialisation();
        PowerManager.powerLeft = 100f;

        if (tabletteController.openTablette == true)
        {
            tabletteController.OpenCloseTablette();
        }

        if (doorControllerLeft.doorIsOpen == true)
        {
            doorControllerLeft.OnMouseDown();
        }

        if (doorControllerRight.doorIsOpen == true)
        {
            doorControllerRight.OnMouseDown();
        }

        yield return new WaitForSeconds(2f);
        timeActive = true;
        PowerManager.powerCanSink = true;
        animator2.SetBool("displayText", false);
        animator.SetBool("blackScreenLoop", false);
    }

    public void GameOver()
    {
        background.SetActive(true);
        buttonRestart.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

