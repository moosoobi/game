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
    public TextMeshProUGUI Text;
    public QuestState CurrentState;
    public TextMeshProUGUI QuestText;
    public DialogueManager dia;
    public AudioSource QuestSound;
    public GunInventory guninventory;
    public string[] dialogue;
    public string[] dialogue2;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public GameObject GunImage;
    public bool conversation2=false;
    public GameObject player;
    public TextMeshProUGUI Text1;//uitext
    public GameObject text1;//uitext
    public ShootingCircle ShootingCircle;
    public GameObject GunMark;
    public GameObject JMark;
    public GameObject Help;
    public TextMeshProUGUI HelpText;

    public ShootingQuest(QuestState currentState)
    {
        CurrentState=currentState;
    }
    
    void Awake()
    {
        dia=GetComponent<DialogueManager>();
        Description="사격연습을 위해 바닥에서 빛이 나는 위치로 이동하십시오.";
        
        requiredShots=3;
        currentShots=0;
    }
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public void BulletHitTarget()
    {
        if(CurrentState==QuestState.Active){
                player.GetComponent<PlayerMovementScript>().enabled = true;
                dia.upstage();
                CurrentState=QuestState.Completed;
                Text.text="J에게 돌아가십시오.";
                JMark.SetActive(true);
                StartCoroutine(ChangeColor());
                QuestSound.Play();
                text1.SetActive(true);
                Text1.text="숫자키 1번을 눌러 총을 넣을 수 있습니다.";
                StartCoroutine(ExecuteAfterDelayText(2.0f));
                ShootingCircle.gameObject.SetActive(false);
            
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
                    Text.text="지도에 노란색으로 표시된 건물로 이동하십시오.";
                    
                }
                
            
            }
            if(Input.GetMouseButtonDown(0)&&isTalking==true&&CurrentState!=QuestState.Completed){
                
                ContinueConversation();          
            }
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length&&CurrentState!=QuestState.Completed){
                EndDialogue();
            }


        
        
    }
    public void Active(){
        CurrentState=QuestState.Active;
    }
    public void QuestActive(){
        
        QuestSound.Play();
        StartConversation();

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
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=" ";
        npcDialogueBox.text=dialogue[0];
        GunImage.SetActive(true);

        GunMark.SetActive(false);
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
        Text.text=Description;
        StartCoroutine(ChangeColor());
        isTalking=false;
        dialogueUI.SetActive(false);
        GunImage.SetActive(false);
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        ShootingCircle.Active=true;
        ShootingCircle.gameObject.SetActive(true);
        Help.SetActive(true);
        HelpText.text="2번: 총 꺼내기\n좌클릭: 발사\n우클릭: 조준\nR: 장전";
    }

    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        text1.SetActive(false);
    }
}
