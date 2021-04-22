using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamManager : MonoBehaviour
{
    public static CamManager Instance;

    public List<GameObject> normalCam = new List<GameObject>();

    //public List<Material> camMaterials;

    private void Awake()
    {
        Instance = this;
    }
}

