using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickKey : MonoBehaviour
{
    public GunInventory guninventory;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public bool zzz=false;
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public bool Detail=false;
    public GameObject player;

    void Update()
    {
        if(Detail){
            if(Input.GetMouseButtonDown(0)&&zzz&&isTalking==false){
                StartConversation();   
            }
            if(Input.GetMouseButtonDown(0)&&isTalking==true){
                    
                ContinueConversation();          
            }
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
        }
        if(Input.GetMouseButtonDown(0)&&zzz){
            guninventory.PositiveKey();
            UiObject.SetActive(true);
            UiText.text="열쇠를 획득했다. 숫자키 3번을 눌러 손에 들 수 있다.";
            StartCoroutine(ExecuteAfterDelayText(2f)); 
        }
        
    }
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    public void StartConversation(){
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
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
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        guninventory.PositiveKey();
        UiObject.SetActive(true);
        UiText.text=" 열쇠를 획득했다. 숫자키 3번을 눌러 손에 들 수 있다.";
        StartCoroutine(ExecuteAfterDelayText(3f)); 
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
