using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking=false;

    float distance;
    int curResponseTracker=0;
    
    public GameObject player;
    public GameObject dialogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;


    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver()
    {
        distance=Vector3.Distance(player.transform.position,this.transform.position);
        if(distance <=2.5f){
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
            /*
            if(curResponseTracker==0&&npc.playerDialogue.Length>=0){
                playerResponse.text=npc.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Return)){
                    npcDialogueBox.text=npc.dialogue[1];
                }
            }
            else if(curResponseTracker==1&&npc.playerDialogue.Length>=1){
                playerResponse.text=npc.playerDialogue[1];
                if(Input.GetKeyDown(KeyCode.Return)){
                    npcDialogueBox.text=npc.dialogue[2];
                }
            }
            */
        }
    }

    void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=npc.name;
        npcDialogueBox.text=npc.dialogue[0];
        
    }

    void EndDialogue(){
        isTalking=false;
        dialogueUI.SetActive(false);
    }
 
}
