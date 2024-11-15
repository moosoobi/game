using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator JAni=null;
    public GameObject JMark;
    public GameObject MapMark;
    public string name;
    public string[] dialogue;
    public string[] dialogue2;
    public string[] dialogue3;
    public string[] dialogue4;

    public bool isTalking=false;
    private bool zzz=false;
    public bool first=true;

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

    public bool Look=false;
    public GameObject J;
    public GameObject Help;
    public TextMeshProUGUI HelpText;
    public AudioSource QuestSound;
    public AudioSource DialogueSound;
    public GameObject Quest1;
    void Start()
    {
        dialogueUI.SetActive(false);
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
    }

    
    void Update()
    {
        
            
        if(Look){
            Vector3 directionToPlayer = player.transform.position - J.transform.position;
            directionToPlayer.y = 0f; // Y축 방향은 무시 (수평 방향으로만 회전)
            // 방향 벡터를 바탕으로 회전 값 생성
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            // 적의 회전을 부드럽게 설정
            J.transform.rotation = targetRotation;
        }
        
        if(zzz){
        
            
               
        
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false){
                StartConversation();
                StartCoroutine(Looking());
                
            }
            
   
        }
        if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==true){
                
                ContinueConversation();          
        }

        if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
                if(stage==0){
                    if(curResponseTracker==dialogue.Length){
                        EndDialogue();
                    }
                }
                else if(stage==1){
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
        if(stage==4){}
        else if(stage==0){
            if(first){

                first=false;
                player.GetComponent<MouseLookScript>().enabled = false;
                player.GetComponent<PlayerMovementScript>().enabled = false;
                isTalking=true;
                curResponseTracker=0;
                dialogueUI.SetActive(true);
                npcName.text="J";
                npcDialogueBox.text=dialogue[0];
            }
        }
        else{
            player.GetComponent<MouseLookScript>().enabled = false;
            player.GetComponent<PlayerMovementScript>().enabled = false;
            isTalking=true;
            curResponseTracker=0;
            dialogueUI.SetActive(true);
            npcName.text="J";
            
            if(stage==1){npcDialogueBox.text=dialogue2[0];}
            else if(stage==2){npcDialogueBox.text=dialogue3[0];JMark.SetActive(false);Help.SetActive(false);}
            else if(stage==3){npcDialogueBox.text=dialogue4[0];}
        }
        

    }

    public void ContinueConversation(){
        DialogueSound.Play();
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
        curResponseTracker=0;
        GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>().IfCross=true;
        if(stage==0){
            player.GetComponent<PlayerMovementScript>().IfCross=true;
            Help.SetActive(true);
            MapMark.SetActive(true);
            //JAni.Play("Stay", 0, 0.0f);
            Quest1.SetActive(true);
            stage=1;
        }
        if(stage==2){stage=3;QuestSound.Play();Stage1.SetActive(false);}
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
    private IEnumerator Looking(){
        
        Look=true;
        yield return new WaitForSeconds(3.0f);
        Look=false;
    }
    
}

