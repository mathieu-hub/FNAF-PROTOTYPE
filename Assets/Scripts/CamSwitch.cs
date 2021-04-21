using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject normalCam;
    public GameObject activateCam;


    void Start()
    {
        normalCam.SetActive(true);
        activateCam.SetActive(false);
    }

    void ActivateThisCam()
    {

    }
}
