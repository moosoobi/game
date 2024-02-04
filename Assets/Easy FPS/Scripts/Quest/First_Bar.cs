using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class First_Bar : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public string Description;
    public TextMeshProUGUI QuestText;
    public AudioSource RadioSound;
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool zzz=false;
    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
    }
    public void Positivez(){zzz=true;}
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    void Update()
    {

        if(zzz&&isTalking==false){
                StartConversation();   
        }
        if(Input.GetKeyDown(KeyCode.Z)&&isTalking==true){
                
            ContinueConversation();          
        }
        if(Input.GetKeyDown(KeyCode.Z)&&curResponseTracker==dialogue.Length){
            EndDialogue();
        }
    }
    public void StartConversation(){
        RadioSound.Play();
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
        npcDialogueBox.text=dialogue[0];
        zzz=false;


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
        QuestActive();
    }
}
