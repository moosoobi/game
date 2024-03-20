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
    public string[] dialogue4;

    public bool isTalking=false;
    private bool zzz=false;

    public int curResponseTracker=0;
    public int stage=0;
    
    public GameObject player;
    public GameObject dialogueUI;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;
    public GunInventory guninventory;
    public ShootingQuest shoot;
    
    public PickMap pickmap;
    private bool pickmapbool=false;

    public GameObject Stage1;

    void Start()
    {
        dialogueUI.SetActive(false);
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
    }

    
    void Update()
    {
        
        if(zzz){
        
            
               
        
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false){
                StartConversation();
            }
            
   
        }
        if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==true){
                
                ContinueConversation();          
        }

        if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
                
                if(stage==1){
                    if(curResponseTracker==dialogue2.Length){
                        EndDialogue();
                    }
                }
                else if(stage==2){
                    if(curResponseTracker==dialogue3.Length){
                        EndDialogue();
                    }
                }
                else if(stage==3){
                    if(curResponseTracker==dialogue4.Length){
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
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
        if(stage==0){}
        else if(stage==1){npcDialogueBox.text=dialogue2[0];}
        else if(stage==2){npcDialogueBox.text=dialogue3[0];}
        else if(stage==3){npcDialogueBox.text=dialogue4[0];}

    }

    public void ContinueConversation(){
        if(stage==0){
                    
        }else if(stage==1){
                    curResponseTracker++;
                    if(curResponseTracker>dialogue2.Length){
                        curResponseTracker=dialogue2.Length;
                    }
                    else if(curResponseTracker<dialogue2.Length)
                    {
                        npcDialogueBox.text=dialogue2[curResponseTracker];
                    }
        }else if(stage==2){
                    curResponseTracker++;
                    if(curResponseTracker>dialogue3.Length){
                        curResponseTracker=dialogue3.Length;
                    }
                    else if(curResponseTracker<dialogue3.Length)
                    {
                        npcDialogueBox.text=dialogue3[curResponseTracker];
                    }
        }else if(stage==3){
                    curResponseTracker++;
                    if(curResponseTracker>dialogue4.Length){
                        curResponseTracker=dialogue4.Length;
                    }
                    else if(curResponseTracker<dialogue4.Length)
                    {
                        npcDialogueBox.text=dialogue4[curResponseTracker];
                    }
        }
    }

    public void EndDialogue(){

        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        isTalking=false;
        dialogueUI.SetActive(false);
        if(stage==0){
            stage=1;
            UiObject.SetActive(true);
            UiText.text="마우스 좌클릭으로 오브젝트와 상호작용할 수 있습니다.";
            StartCoroutine(ExecuteAfterDelayText(3f)); 
        }
        if(stage==2){stage=3;Stage1.SetActive(false);}
        if (stage == 3) { stage = 4; }

        if (!pickmapbool){
            pickmapbool=true;
            pickmap.QuestActive();
        }

    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        
    }
    
}

