using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController2 : MonoBehaviour
{
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;
    public bool zzzz=false;
    public bool first=true;


    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public string dooropen;
    public string doorclose;
    

    public int stack=0;

    

    public GameObject cross;
    public pick pick;
    public GunInventory guninventory;
    
    void Update()
    {
        
        if(zzzz){
            if (Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
            if(openTrigger&&first){
                myDoor.Play(dooropen, 0, 0.0f);
                closeTrigger=true;
                openTrigger=false;
                if (DrawerOpen)
				DrawerOpen.Play ();
                StartCoroutine(ExecuteAfterDelay(1f));
                first=false;
            }
            else if(closeTrigger){

                if(stack==0){stack++;}
                else if(stack==1){
                    stack=0;
                    
                    closeTrigger=false;
                    openTrigger=true;
                    if (DrawerClose)
                    
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
