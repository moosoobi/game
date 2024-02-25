using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Animator myDoor=null;

    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public string dooropen;
    public string doorclose;
    
    public bool openTrigger=true;
    public bool closeTrigger=false;

    public bool zzzz=false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            zzzz=true;
            if(openTrigger){
                    myDoor.Play(dooropen, 0, 0.0f);
                    closeTrigger=true;
                    openTrigger=false;
                    if (DrawerOpen)
                    DrawerOpen.Play ();
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            zzzz=false;
            if(closeTrigger){
                myDoor.Play(doorclose, 0, 0.0f);
                closeTrigger=false;
                openTrigger=true;
                if (DrawerClose)
                DrawerClose.Play ();
            }
        }
    }

}
