using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickCard : MonoBehaviour
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
    private bool Clear=false;
    public Kiosk kiosk;
    
    void Update()
    {
        if(Clear){
            if(zzz&&Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false){
            guninventory.PositiveCard();
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
    public void PositiveClear(){Clear=true;kiosk.Possible=true;}
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        Destroy(gameObject);
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
        UiObject.SetActive(true);
        UiText.text="3번을 눌러 카드를 꺼내십시오.";
        StartCoroutine(ExecuteAfterDelayText(3f)); 
        
    }

}
