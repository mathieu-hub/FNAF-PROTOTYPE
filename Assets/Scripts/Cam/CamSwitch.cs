using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> uiNormalCam; 

    [SerializeField]
    private GameObject selectNormalCam;

    public void Awake()
    {
        uiNormalCam = CamManager.Instance.normalCam;
    }

    public void Start()
    {
        selectNormalCam = uiNormalCam[0];
    }

    public void Active1A()
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

        selectNormalCam = CamManager.Instance.normalCam[0];
        CamManager.Instance.normalCam.Remove(CamManager.Instance.normalCam[0]);
        Debug.Log("Click 1A");
        StartCoroutine(DisplayUiCam()); 
    }

    IEnumerator DisplayUiCam()
    {
        yield return new WaitForSeconds(0.3f);
        selectNormalCam.SetActive(false);
        Debug.Log("Active 1A");
    }

    public void Active1B()
    {
        Debug.Log("Click 1B");
    }
}
