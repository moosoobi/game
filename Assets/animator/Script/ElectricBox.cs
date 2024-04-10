using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElectricBox : MonoBehaviour
{
    public GunInventory guninventory;
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;

    public GameObject KeyUi;
    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public string dooropen;
    public string doorclose;
    public bool doorlock=false;

    public bool zzzz=false;

    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool talked=false;


    
    void Update()
    {
        
        if(zzzz){
            if(Input.GetMouseButtonDown(0)&&guninventory.currneguniskey()){
                        Positivedoorlock();
                        
            }else if(Input.GetMouseButtonDown(0)&&!guninventory.currneguniskey()&&isTalking==false&&!doorlock){
                        StartConversation();    
            }
        
        
            if(Input.GetMouseButtonDown(0)&&isTalking==true){
            
                ContinueConversation();          
            }
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
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
        KeyUi.SetActive(false);
        
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
    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="주인공";
        npcDialogueBox.text=dialogue[0];
        

    }
    public void ContinueConversation(){
            curResponseTracker++;
            if(curResponseTracker>dialogue.Length){
                curResponseTracker=dialogue.Length;
            }
            else if(curResponseTracker<dialogue.Length)
            {
                npcDialogueBox.text=dialogue[curResponseTracker];
            }
    }
    public void EndDialogue(){
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        
    }

}

