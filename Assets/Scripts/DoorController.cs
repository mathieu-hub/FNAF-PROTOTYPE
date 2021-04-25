using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public bool doorIsOpening;
    public bool doorIsClosing;
    public bool doorIsOpen;

    [Range(5f,10f)]
    public float speedOpening;


    void Update()
    {
        //if bool is true, *open the door* 
        if(doorIsOpening == true)
        {
            door.transform.Translate(Vector3.back * Time.deltaTime * speedOpening);
        }       
        
        //if the z position of the door is < than -19 *stop opening of the door*
        if (door.transform.position.z < -19)
        {
            doorIsOpening = false;
            doorIsOpen = true;
        }

        if (doorIsClosing == true)
        {
            door.transform.Translate(Vector3.forward * Time.deltaTime * speedOpening);
        }

        if (door.transform.position.z > -15.18)
        {
            doorIsClosing = false;
            doorIsOpen = false;
        }
    }

    public void OnMouseDown() //LAUNCH WHEN THE MOUSE CLICK ON THE COLLIDER OF THE OBJECT WHICH CONTAIN THE SCRIPT
    {
        if(doorIsOpen == false)
        {
            doorIsOpening = true; //Opening the door link to the button when we click on it
            PowerManager.Instance.poweredObjects += 1;
        }
        else if (doorIsOpen == true)
        {
            doorIsClosing = true; //Closing the door link to the button when we click on it
            PowerManager.Instance.poweredObjects -= 1;
        }
    }
}
