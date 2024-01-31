using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController2 : MonoBehaviour
{
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;


    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public string dooropen;
    public string doorclose;

    public int stack=0;
    public bool zzzz=false;

    public GameObject cross;
    public pick pick;
    
    void Update()
    {
        
        if(zzzz){
            if (Input.GetKeyDown(KeyCode.Z)){
            if(openTrigger){
                myDoor.Play(dooropen, 0, 0.0f);
                closeTrigger=true;
                openTrigger=false;
                if (DrawerOpen)
				DrawerOpen.Play ();
                StartCoroutine(ExecuteAfterDelay(1f));
            }
            else if(closeTrigger){

                if(stack==0){stack++;}
                else if(stack==1){
                    stack=0;
                    myDoor.Play(doorclose, 0, 0.0f);
                    closeTrigger=false;
                    openTrigger=true;
                    if (DrawerClose)
                    DrawerClose.Play ();
                    StartCoroutine(ExecuteAfterDelay(1f));
                }
            }
            }

        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        
        zzzz=true;
        StartCoroutine(ExecuteAfterDelay(0.5f));
        
    }
    
    
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        zzzz=false;
    }

}
