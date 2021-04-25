using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletteController : MonoBehaviour
{
    public Animator anim;
    public GameObject mapDisplay;
    public GameObject camButtons;
    
    public Material camDisplay;
    Renderer rend;

    public bool openTablette;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true; 
    }

    private void Update()
    {
        openTablette = anim.GetBool("OpenTablette");
        camDisplay = CamManager.Instance.camVisualizer;
        rend.sharedMaterial = camDisplay;
    }

    public void OpenCloseTablette()
    {
        if (openTablette == false) 
        {
            anim.SetBool("OpenTablette", true);
            PowerManager.Instance.poweredObjects += 1;
            StartCoroutine(TimeToDisplay());            
        }
        else if (openTablette == true)
        {
            anim.SetBool("OpenTablette", false);
            mapDisplay.SetActive(false);
            camButtons.SetActive(false);
            PowerManager.Instance.poweredObjects -= 1;
        }
    }

    IEnumerator TimeToDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        mapDisplay.SetActive(true);
        camButtons.SetActive(true);
    }
}
