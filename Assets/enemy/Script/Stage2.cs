using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage2 : MonoBehaviour
{
    
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public GameObject player;
    public bool isTalking=false;



    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
            ContinueConversation();          
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
            EndDialogue();
        }
    }
    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
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
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(isTalking==false){StartConversation();}
        
    }
}
