using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CamManager 
{
    public static CamManager instance;

    public ArrayList[] normalCam;
    public ArrayList[] activateCam;
    public ArrayList[] actualStateCam;

    public List<GameObject> listDeCam;

    void Start()
    {
        normalCam = new ArrayList[11];
        activateCam = new ArrayList[11];
        actualStateCam = new ArrayList[11];
    }
}
