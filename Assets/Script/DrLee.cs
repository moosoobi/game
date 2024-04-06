using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrLee : MonoBehaviour
{
   
    public GameObject player;
    public string[] dialogue;
    public string[] dialogue1;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public int Stage=0;
    public bool Conversation=false;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI QuestText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
                
            ContinueConversation();          
        }
        if(Stage==0){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
        }else if(Stage==1){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue1.Length){
                EndDialogue();
            }
        }
    }

    public void StartConversation(){
        if(!Conversation){
            
            isTalking=true;
            curResponseTracker=0;
            dialogueUI.SetActive(true);
            npcName.text="이선생";
            if(Stage==0){npcDialogueBox.text=dialogue[0];}
            if(Stage==1){npcDialogueBox.text=dialogue1[0];}
            player.GetComponent<MouseLookScript>().enabled = false;
            player.GetComponent<PlayerMovementScript>().enabled = false;
        
        }
            


    }


    public void ContinueConversation(){
            curResponseTracker++;
            if(Stage==0){
                if(curResponseTracker>dialogue.Length){
                    curResponseTracker=dialogue.Length;
                }
                else if(curResponseTracker<dialogue.Length)
                {
                    npcDialogueBox.text=dialogue[curResponseTracker];
                }
            }else if(Stage==1){
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
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        QuestActive();
        if(Stage==0){
            QuestActive();
            player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
        }
        Conversation=true;
        
    }
    public void QuestActive(){
        Text.text="메인컴퓨터에 해킹프로그램을 설치하라.";
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            Stage=1;
            StartConversation();
            
        }
    }
}
