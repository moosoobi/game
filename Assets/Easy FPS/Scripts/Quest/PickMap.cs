using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickMap : MonoBehaviour
{
    public GameObject map;
    public GameObject map2;
    public bool zzz=false;
    public bool ifpick=false;
    public bool show=true;
    public bool z;
    public TextMeshProUGUI Text;//uitext
    public GameObject text1;//uitext
    public TextMeshProUGUI Text2;//questtext
    public DialogueManager dia;
    public GunPick gunpick;
    private bool gunpickbool=false;
    public TextMeshProUGUI QuestText;
    private string Description="책상에서 지도를 얻어라.";
    public AudioSource QuestSound;
    public GunInventory guninventory;
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public bool Detail=false;
    public GunScript gun;

    void Update()
    {
        
        if(zzz&&dia.stage==1){
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
                text1.SetActive(true);
                Text.text="X를 누르면 지도를 확인할 수 있습니다.";
                StartCoroutine(ExecuteAfterDelayText(3f));
                ifpick=true;
                if(!gunpickbool){
                    gunpickbool=true;
                    gunpick.QuestActive();
                }
            }
        }
        if(ifpick){
            if(Input.GetKeyDown(KeyCode.X)){
                gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
                if(show){
                    gun.zcross1=false;
                    map.SetActive(true);
                    map2.SetActive(true);
                    
                    
                }else if(!show){
                    gun.zcross1=true;
                    map.SetActive(false);

                    
                }
                show=!show;
                
            }
        }
        if(Detail){
            if(Input.GetMouseButtonDown(0)&&zzz&&isTalking==false&&dia.stage==1){
                StartConversation();   
            }
            if(Input.GetMouseButtonDown(0)&&isTalking==true){
                    
                ContinueConversation();          
            }
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
        }
        
    }
    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="주인공";
        npcDialogueBox.text=dialogue[0];
        zzz=false;


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
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    public void QuestActive(){
        Text2.text="책상에서 지도를 얻어라.";
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
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        text1.SetActive(false);
    }
}
