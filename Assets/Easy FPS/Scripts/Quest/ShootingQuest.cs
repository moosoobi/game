using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingQuest : Quest
{
    public string Description;
    public int requiredShots;
    public int currentShots;  
    public bool zzz=false;
    public string[] dialogue;
    public TextMeshProUGUI Text;
    public QuestState CurrentState;
    public TextMeshProUGUI QuestText;
    public DialogueManager dia;
    public AudioSource QuestSound;
    public GunInventory guninventory;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    
    public ShootingQuest(QuestState currentState)
    {
        
    
        CurrentState=currentState;
        
    }
    
    void Awake()
    {
        dia=GetComponent<DialogueManager>();
        Description="마네킹의 머리 가슴 배를 사격하십시오.";
        requiredShots=3;
        currentShots=0;
    }
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public void BulletHitTarget()
    {
        if(CurrentState==QuestState.Active){

                dia.upstage();
                CurrentState=QuestState.Completed;
                Text.text="퀘스트 완료 npc에게 돌아가십시요.";
                StartCoroutine(ChangeColor());
                QuestSound.Play();
            
        }
    }
    
    
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    private void Update() {
        
            if(zzz&&Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
            
                if(CurrentState==QuestState.Completed){
                    StartCoroutine(ChangeColor());
                    QuestSound.Play();
                    Text.text="지도를 보고 목표지점으로 이동하시오.";
                }
                
            
            }
            if(Input.GetMouseButtonDown(0)&&isTalking==true){
                
                ContinueConversation();          
            }
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }

        
        
    }
    public void Active(){
        CurrentState=QuestState.Active;
        StartConversation();
    }
    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
        QuestSound.Play();
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
     public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
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
        isTalking=false;
        dialogueUI.SetActive(false);
    }
}
