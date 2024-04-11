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
    public bool zzz=false;
    public GunInventory guninventory;
    public bool IfRed=false;
    public GameObject player;
    void Update()
    {
        
        if(zzz){
     
                
               
        
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false){
                StartConversation();
                
            }
            else if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==true){
                EndDialogue();
            }
            
        }
    }
    public void StartConversation(){
        if(IfRed){npcDialogueBox.color=Color.red;}
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
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
        if(IfRed){npcDialogueBox.color=Color.white;}
        isTalking=false;
        dialogueUI.SetActive(false);
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;

    }
    private void OnTriggerEnter(Collider other)
    {    
        if (other.CompareTag("Player")){
            zzz=true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {    
        if (other.CompareTag("Player")){
            zzz=false;
        }
    }
    
}
