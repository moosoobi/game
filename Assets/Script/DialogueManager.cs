using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking=false;

    int curResponseTracker=0;
    
    public GameObject player;
    public GameObject dialogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;
    
    private bool zzz=false;
    

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    
    void Update()
    {
        if(zzz){
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==true){
                curResponseTracker++;
                if(curResponseTracker>=npc.dialogue.Length-1){
                    curResponseTracker=npc.dialogue.Length-1;
                }
                npcDialogueBox.text=npc.dialogue[curResponseTracker];
               
            }
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==false){
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.Z)&&curResponseTracker==npc.dialogue.Length-1){
                EndDialogue();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {    
            zzz=true;
    }
    private void OnTriggerExit(Collider other)
    {    
            zzz=false;
    }
    

    void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=npc.name;
        npcDialogueBox.text=npc.dialogue[0];
        npc.Quest.AcceptQuest();
    }

    void EndDialogue(){
        isTalking=false;
        dialogueUI.SetActive(false);
    }
 
}
