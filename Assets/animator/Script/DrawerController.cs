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

    public string dooropen;
    public string doorclose;

    private bool zzzz=false;

    
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
    private void OnTriggerStay(Collider other)
    {
        
        zzzz=true;
            
        
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        zzzz=false;
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);

    }

}
