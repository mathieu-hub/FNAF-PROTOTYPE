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
    public Text textBox;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = timeStart;
        textBox.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textBox.text = Mathf.Round(timer).ToString();
    }
}
