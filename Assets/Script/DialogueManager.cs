using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    
    public string name;
    public string[] dialogue;
    public string[] dialogue2;
    public string[] dialogue3;

    public bool isTalking=false;
    private bool zzz=false;

    public int curResponseTracker=0;
    public int stage=0;
    
    public GameObject player;
    public GameObject dialogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;
    
    public GunPick gunpick;
    private bool gunpickbool=false;

    void Start()
    {
        dialogueUI.SetActive(false);
        gunpick=GetComponent<GunPick>();
    }

    
    void Update()
    {
        if(zzz){
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==true){
                
                ContinueConversation();          
            }
                
               
        
            if(Input.GetKeyDown(KeyCode.Z)&&isTalking==false){
                StartConversation();
                
            }
            else if(Input.GetKeyDown(KeyCode.Z)){
                if(curResponseTracker==dialogue.Length){
                    EndDialogue();
                    
                }
                
                
            }
        }
    }
    public void upstage(){stage++;}
    private void OnTriggerEnter(Collider other)
    {    
            zzz=true;
    }
    private void OnTriggerExit(Collider other)
    {    
            zzz=false;
    }
    public void Positivezzz(){zzz=true;}
    public void Negativezzz(){zzz=true;}

    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
        if(stage==0){npcDialogueBox.text=dialogue[0];}
        else if(stage==1){npcDialogueBox.text=dialogue2[0];}

    }

    public void ContinueConversation(){
        if(stage==0){
                    curResponseTracker++;
                    if(curResponseTracker>dialogue.Length){
                        curResponseTracker=dialogue.Length;
                    }
                    else if(curResponseTracker<dialogue.Length)
                    {
                        npcDialogueBox.text=dialogue[curResponseTracker];
                    }
        }else if(stage==1){
                    curResponseTracker++;
                    if(curResponseTracker>dialogue2.Length){
                        curResponseTracker=dialogue2.Length;
                    }
                    else if(curResponseTracker<dialogue2.Length)
                    {
                        npcDialogueBox.text=dialogue2[curResponseTracker];
                    }
        }
    }

    public void EndDialogue(){
        isTalking=false;
        dialogueUI.SetActive(false);
        if(stage==0){stage=1;}
        
        if(!gunpickbool){
            gunpickbool=true;
            gunpick.QuestActive();
        }
    }
    
}

