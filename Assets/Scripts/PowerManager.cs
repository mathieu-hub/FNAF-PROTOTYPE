using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public static PowerManager Instance;
    
    public float powerLeft;
    public float powerSink = 0.1f;
    public int poweredObjects;

    [Header("POWER COUNTER")]
    public List<GameObject> usageCount;
    public Text powerLeftText;
    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        powerLeft = 100f;
        poweredObjects = 1;
        powerLeftText.text = "Power Left : " + Mathf.Round(powerLeft).ToString() + "%";
    }

    private void OnGUI()
    {
        GUILayout.Label(powerLeft.ToString());
    }

    void Update()
    {
        powerLeft -= powerSink * Time.deltaTime;
        powerLeftText.text = "Power Left : " + Mathf.Round(powerLeft).ToString() + "%";
        UsePower();
    }

    public void UsePower()
    {
        if(poweredObjects == 1)
        {
            powerSink = 0.1f;
            usageCount[0].SetActive(true);
            usageCount[1].SetActive(false);
            usageCount[2].SetActive(false);
            usageCount[3].SetActive(false);
            usageCount[4].SetActive(false);
            usageCount[5].SetActive(false);
        }
        else if (poweredObjects == 2)
        {
            powerSink = 0.2f;
            usageCount[0].SetActive(true);
            usageCount[1].SetActive(true);
            usageCount[2].SetActive(false);
            usageCount[3].SetActive(false);
            usageCount[4].SetActive(false);
            usageCount[5].SetActive(false);
        }
        else if (poweredObjects == 3)
        {
            powerSink = 0.3f;
            usageCount[0].SetActive(true);
            usageCount[1].SetActive(true);
            usageCount[2].SetActive(true);
            usageCount[3].SetActive(false);
            usageCount[4].SetActive(false);
            usageCount[5].SetActive(false);
        }
        else if (poweredObjects == 4)
        {
            powerSink = 0.4f;
            usageCount[0].SetActive(true);
            usageCount[1].SetActive(true);
            usageCount[2].SetActive(true);
            usageCount[3].SetActive(true);
            usageCount[4].SetActive(false);
            usageCount[5].SetActive(false);
        }
        else if (poweredObjects == 5)
        {
            powerSink = 0.5f;
            usageCount[0].SetActive(true);
            usageCount[1].SetActive(true);
            usageCount[2].SetActive(true);
            usageCount[3].SetActive(true);
            usageCount[4].SetActive(true);
            usageCount[5].SetActive(false);
        }
        else if (poweredObjects == 6)
        {
            powerSink = 0.6f;
            usageCount[0].SetActive(true);
            usageCount[1].SetActive(true);
            usageCount[2].SetActive(true);
            usageCount[3].SetActive(true);
            usageCount[4].SetActive(true);
            usageCount[5].SetActive(true);
        }
    }
}
