using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public ArrayList[] normalCam;
    public ArrayList[] activateCam;
    public ArrayList[] actualStateCam;

    void Start()
    {
        normalCam = new ArrayList[11];
        activateCam = new ArrayList[11];
        actualStateCam = new ArrayList[11];
    }
}
