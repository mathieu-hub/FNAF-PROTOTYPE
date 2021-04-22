using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> uiNormalCam = new List<GameObject>(); 

    [SerializeField]
    private GameObject selectNormalCam;    

    public void Start()
    {
        uiNormalCam = CamManager.Instance.normalCam;
        selectNormalCam = uiNormalCam[0];
    }

    public void ActiveCam(GameObject currentCam)
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
        Debug.Log("Click 1A");
        StartCoroutine(DisplayUiCam()); 
    }

    IEnumerator DisplayUiCam()
    {
        yield return new WaitForSeconds(0.3f);
        selectNormalCam.SetActive(false);
        Debug.Log("Active 1A");
    }
    
}
