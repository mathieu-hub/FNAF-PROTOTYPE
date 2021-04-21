using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletteController : MonoBehaviour
{
    public Animator anim;
    public GameObject mapDisplay; 

    [SerializeField]
    private bool openTablette;


    private void Update()
    {
        openTablette = anim.GetBool("OpenTablette");
    }

    public void OpenCloseTablette()
    {
        if (openTablette == false) 
        {
            anim.SetBool("OpenTablette", true);
            StartCoroutine(TimeToDisplay());            
        }
        else if (openTablette == true)
        {
            anim.SetBool("OpenTablette", false);
            mapDisplay.SetActive(false);
        }
    }

    IEnumerator TimeToDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        mapDisplay.SetActive(true);
    }
}
