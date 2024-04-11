using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickCard : MonoBehaviour
{
    public GunInventory guninventory;
    public GameObject CardUi;
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
    public GameObject player;
    public GameObject Key;
    public GameObject CardMark;
    
    void Update()
    {
        
        if(zzz&&Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false){
        guninventory.PositiveCard();
        UiObject.SetActive(true);
        UiText.text="카드키를 획득했다. 숫자키 4번을 눌러 손에 들 수 있다";
        Key.SetActive(true);
        CardMark.SetActive(false);
        CardUi.SetActive(true);
        StartCoroutine(ExecuteAfterDelayText(3f)); 
        //StartConversation();
        }
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
            ContinueConversation();          
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
            EndDialogue();
        }
        
        
    }
    public void PositiveClear(){Clear=true;kiosk.Possible=true;}
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            zzz=true;
        }
    }
    private void OnTriggerExit(Collider other){

        if (other.CompareTag("Player")){
            zzz=false;
        }
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
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;

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
        UiText.text="카드키를 획득했다. 숫자키 4번을 눌러 손에 들 수 있다";
        StartCoroutine(ExecuteAfterDelayText(3f)); 
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        
    }

}
