using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    [SerializeField] public Animator myDoor=null;

    [SerializeField] private bool openTrigger=false;
    [SerializeField] private bool closeTrigger=false;


    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;


  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            if(openTrigger){
                myDoor.Play("DrawerOpen", 0, 0.0f);
                closeTrigger=true;
                openTrigger=false;
                if (DrawerOpen)
				DrawerOpen.Play ();
                
            }
            else if(closeTrigger){
                myDoor.Play("DrawerClose", 0, 0.0f);
                closeTrigger=false;
                openTrigger=true;
                if (DrawerClose)
				DrawerClose.Play ();
                
            }
            
        }
    }
}
