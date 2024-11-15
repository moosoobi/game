using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyCoreDoor : MonoBehaviour
{
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;

    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;
    public AudioSource RadioSound;
    public AudioSource QuestSound;
    public AudioSource DialogueSound;

    public string dooropen;
    public string doorclose;
    

    public bool zzzz=false;

    public GunInventory guninventory;

    public EnergyCore EnergyCore;

    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI QuestText;
    public TextMeshProUGUI Text2;//questtext
    public GameObject dialogueUI;
    public GameObject player;
    public bool isTalking=false;
    public GameObject Guide;
    public GameObject Guide1;
    public GameObject ShootCircle;
    public GameObject ShootGuide;
    
    void Update()
    {
        
        if(zzzz){
            if (Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&openTrigger==true){
                    
            }
        }
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
                
            ContinueConversation();          
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
            EndDialogue();
            QuestActive();
        }
    }
    public void CoreCircle(){
        Guide.SetActive(false);
        Guide1.SetActive(false);
        myDoor.Play(dooropen, 0, 0.0f);
        closeTrigger=true;
        openTrigger=false;
        if (DrawerOpen)
        DrawerOpen.Play ();
        StartCoroutine(ExecuteAfterDelay(1f));
        StartConversation();
    }
    public void QuestActive(){
        //ShootCircle.SetActive(true);
        ShootGuide.SetActive(true);
        Text2.text="에너지증폭장치를 파괴하십시오.";
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        QuestSound.Play();
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            zzzz=true;
            StartCoroutine(ExecuteAfterDelay(0.5f));
        }
        
        
    }
    
    
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        zzzz=false;
    }
    public void StartConversation(){
        player.GetComponent<GunInventory>().Possible=false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        RadioSound.Play();
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text=dialogue[0];


    }
    public void ContinueConversation(){
            DialogueSound.Play();
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
        player.GetComponent<GunInventory>().Possible=true;
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        EnergyCore.Open=true;
    }
}
