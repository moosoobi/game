using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;
    public string[] storySentences1;
    public string[] storySentences2;
    public string[] storySentences3;

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
                if(curResponseTracker>npc.dialogue.Length){
                    curResponseTracker=npc.dialogue.Length;
                }
                else if(curResponseTracker<npc.dialogue.Length)
                {
                    npcDialogueBox.text=npc.dialogue[curResponseTracker];
                }
            }
                
               
        
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==false){
                StartConversation();
                
            }
            else if(Input.GetKeyDown(KeyCode.Z)){
                if(curResponseTracker==npc.dialogue.Length){
                    EndDialogue();
                    
                }
                
                
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
        
        
        
    }

    void EndDialogue(){
        isTalking=false;
        dialogueUI.SetActive(false);
    }
    
}

