using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarNpc : MonoBehaviour
{
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool zzz=false;
    void Update()
    {
        if(zzz){
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==true){
                
                ContinueConversation();          
            }
                
               
        
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==false){
                StartConversation();
                
            }
            else if(Input.GetKeyDown(KeyCode.Z)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
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
    private void OnTriggerEnter(Collider other)
    {    
            zzz=true;
    }
    private void OnTriggerExit(Collider other)
    {    
            zzz=false;
    }
}
