using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CamManager 
{
    public static CamManager Instance;

    [Header("Normal Camera")]
    public GameObject cam1A;
    public GameObject cam1B;
    public GameObject cam1C;
    public GameObject cam2A;
    public GameObject cam2B;
    public GameObject cam3;
    public GameObject cam4A;
    public GameObject cam4B;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;

    [Header("Material Cam Visualizer")]
    public Material mCam1A;
}

