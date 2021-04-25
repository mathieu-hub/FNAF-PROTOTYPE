using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public static PowerManager Instance;
    
    public float powerLeft;
    public float powerSink = 0.1f;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        powerLeft = 99f;
    }

    private void OnGUI()
    {
        GUILayout.Label(powerLeft.ToString());
    }

    void Update()
    {
        
    }
}
