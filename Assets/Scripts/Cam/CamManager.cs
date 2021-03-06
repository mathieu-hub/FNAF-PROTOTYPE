using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamManager : MonoBehaviour
{
    public static CamManager Instance;

    public List<GameObject> normalCam = new List<GameObject>();

    public List<Material> camMaterials = new List<Material>();

    public Material camVisualizer;

    private void Awake()
    {
        Instance = this;
    }
}

