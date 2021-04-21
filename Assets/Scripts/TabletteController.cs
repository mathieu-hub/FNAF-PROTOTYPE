using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletteController : MonoBehaviour
{
    public Animator anim;

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
        }
        else if (openTablette == true)
        {
            anim.SetBool("OpenTablette", false);
        }
    }
}
