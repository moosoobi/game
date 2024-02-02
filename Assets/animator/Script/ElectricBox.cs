using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour
{
    public GunInventory gunInventory;
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;


    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public string dooropen;
    public string doorclose;

    public bool zzzz=false;

    
    void Update()
    {
        
        if(zzzz){
            if (Input.GetKeyDown(KeyCode.Z)&&gunInventory.IfKey==true&&openTrigger==true){
                if(openTrigger){
                    myDoor.Play(dooropen, 0, 0.0f);
                    closeTrigger=true;
                    openTrigger=false;
                    if (DrawerOpen)
                    DrawerOpen.Play ();
                    StartCoroutine(ExecuteAfterDelay(1f));
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

