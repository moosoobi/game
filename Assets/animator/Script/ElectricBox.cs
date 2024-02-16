using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour
{
    public GunInventory guninventory;
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;


    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public string dooropen;
    public string doorclose;
    public bool doorlock=false;

    public bool zzzz=false;

    
    void Update()
    {
        
        if(zzzz){
            if(Input.GetMouseButtonDown(0)&&!doorlock){
                if(guninventory.currneguniskey()){
                    Positivedoorlock();
                }
            }
            if (Input.GetMouseButtonDown(0)&&doorlock&&openTrigger){
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
    public void Positivedoorlock(){
        doorlock=true;
        guninventory.NegativeKey();
        guninventory.ChangeWeapon1();
        
    }
    public bool ReturnDoorLock(){return doorlock;}
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

