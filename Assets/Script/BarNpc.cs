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
    public bool lock1=false;
    public GameObject player;
    public GameObject[] Key;
    public GameObject Mark;
    
    void Update()
    {
        
        if(zzz){
     
                
            
        
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false&&!lock1){
                player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0,0);
                StartConversation();
                
            }else if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==true){
                EndDialogue();
                if(Mark){Mark.SetActive(false);}
                if(Key.Length!=1){
                    for(int i=0;i<Key.Length;i++){
                        Key[i].SetActive(false);
                    }
                    Key[Key.Length-1].SetActive(true);
                }
            }
            
            
        }
        
    }
    public void StartConversation(){
        if(IfRed){ npcDialogueBox.color = new Color(1.0f, 92.0f / 255.0f, 1.0f); }
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="";
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
