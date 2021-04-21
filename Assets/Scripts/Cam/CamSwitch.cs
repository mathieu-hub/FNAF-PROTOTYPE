using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject normalCam;
    public GameObject activateCam;

    private GameObject thisCam;
    
    public int camIndex;

    void Awake()
    {
        thisCam = this.gameObject;
        //thisCam = CamManager.instance.listDeCam[camIndex]; c'est ça qu'il faut faire.
    }

    void Start()
    {
        normalCam.SetActive(true);
        activateCam.SetActive(false);
    }

    void ActivateThisCam()
    {

    }
}
