using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [Header ("UI CAMERA")]
    [SerializeField]
    private GameObject selectNormalCam;

    [SerializeField]
    private List<GameObject> uiNormalCam = new List<GameObject>(); 

    [Header("MATERIAL CAMERA VISUALIZER")]
    [SerializeField]
    private Material actualMaterialCam;

    [SerializeField]
    private List<Material> materialCam = new List<Material>();


    public void Start()
    {
        uiNormalCam = CamManager.Instance.normalCam;
        selectNormalCam = uiNormalCam[0];

        materialCam = CamManager.Instance.camMaterials;
        actualMaterialCam = materialCam[0];
    }

    public void UiActiveCam(GameObject currentCam)
    {
        if (selectNormalCam != null)
        {
            selectNormalCam.SetActive(true);
            CamManager.Instance.normalCam.Add(selectNormalCam);
        }
        else
        {
            Debug.Log("SelectNormalCam est null");
        }
        
        selectNormalCam = currentCam;
        CamManager.Instance.normalCam.Remove(currentCam);
        Debug.Log("Click Button Cam");
        StartCoroutine(DisplayUiCam()); 
    }

    IEnumerator DisplayUiCam()
    {
        yield return new WaitForSeconds(0.3f);
        selectNormalCam.SetActive(false);
        Debug.Log("Active button Cam");
    }

    public void MaterialActiveCam(Material currentMaterial)
    {
        actualMaterialCam = currentMaterial;
    }
    
}
