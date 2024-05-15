using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EleConver : MonoBehaviour
{
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public GameObject player;
    public bool First=true;
    public AudioSource DialogueSound;
    void Start()
    {
        
    }

    // Update is called once per frame
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
        First=false;
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text=dialogue[0];
    }
    public void ContinueConversation(){
        DialogueSound.Play();
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
        isTalking=false;
        dialogueUI.SetActive(false);
        curResponseTracker=0;
    }
    private void OnTriggerEnter(Collider other)
    {

            
            if(other.CompareTag("Player")){
                if(First){
                    StartConversation();
                }
                
            }
    }
}
