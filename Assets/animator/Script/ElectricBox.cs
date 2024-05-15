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
    public AudioSource DialogueSound;

    public string dooropen;
    public string doorclose;
    public bool doorlock=false;
    public bool dooropenbool=false;

    public bool zzzz=false;

    public string[] dialogue;
    public string[] dialogue1;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool talked=false;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    private int stage=0;
    public GameObject player;
    public GameObject camera;
    public bool clear=false;

    
    void Update()
    {
        
        if(zzzz&&!clear){
            if(Input.GetMouseButtonDown(0)&&guninventory.currneguniskey()){
                        Positivedoorlock();
                        stage=1;
                        Invoke("StartConversation", 1.0f);
                        
            }else if(Input.GetMouseButtonDown(0)&&!guninventory.currneguniskey()&&isTalking==false&&!doorlock){
                        StartConversation();    
            }
        
        
            if(Input.GetMouseButtonDown(0)&&isTalking==true){
            
                ContinueConversation();          
            }
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
            
            
            if (Input.GetMouseButtonDown(0)&&dooropenbool&&openTrigger){
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
        dooropenbool=true;
        guninventory.NegativeKey();
        guninventory.ChangeWeapon1();
        KeyUi.SetActive(false);
        Key1.SetActive(false);
        Key2.SetActive(false);
        Key3.SetActive(false);
        
        
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
        DialogueSound.Play();
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        player.transform.position = new Vector3(354.6f, 1f, 424.16f);
        player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        camera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0,0);
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="";
        if(stage==0){
            npcDialogueBox.text=dialogue[0];
        }else if(stage==1){
            npcDialogueBox.text=dialogue1[0];
        }
        
        

    }
    public void ContinueConversation(){
            curResponseTracker++;
            DialogueSound.Play();
            if(stage==0){
                if(curResponseTracker>dialogue.Length){
                    curResponseTracker=dialogue.Length;
                }
                else if(curResponseTracker<dialogue.Length)
                {
                    npcDialogueBox.text=dialogue[curResponseTracker];
                }
            }else if(stage==1){
                if(curResponseTracker>dialogue1.Length){
                    curResponseTracker=dialogue1.Length;
                }
                else if(curResponseTracker<dialogue1.Length)
                {
                    npcDialogueBox.text=dialogue1[curResponseTracker];
                }
            }
            
    }
    public void EndDialogue(){
        DialogueSound.Play();
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        if(stage==1){stage=2;doorlock=true;}
        
    }
    

}

