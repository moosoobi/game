using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyCore : Quest
{

    public QuestState CurrentState;
    public string[] dialogue;
    public string[] dialogue1;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool zzz=false;
    public GunInventory guninventory;
    public AudioSource SecuritySound;
    static public float CoreHp=10f;
    public float CoreMaxHp=10f;
    public TextMeshProUGUI Core;
    public Slider healthSlider;
    public bool first=false;

     public EnergyCore(QuestState currentState)
    {
        CurrentState=currentState;
    }
    void Update()
    {
        if(zzz){
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==true){
                
                ContinueConversation();          
            }
                
               
        
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&isTalking==false){
                StartConversation();
                
            }
            else if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
        }
    }
    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
        npcDialogueBox.text=dialogue[0];
    }

    private void OnTriggerEnter(Collider other)
    {    
            zzz=true;
            if (other.CompareTag("Attack")){
                if(!first){
                    
                    healthSlider.gameObject.SetActive(true);
                    Core.gameObject.SetActive(true);
                    first=true;
                    healthSlider.maxValue = CoreMaxHp;
                    healthSlider.value = CoreHp;
                    
                }
                UpdateHealth(-1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {    
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
        isTalking=false;
        dialogueUI.SetActive(false);
    }
    public void UpdateHealth(float newHP)
    {

        CoreHp += newHP;

        // 슬라이더에 반영
        healthSlider.value = CoreHp;

        // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
        if (CoreHp <= 0f)
        {
            Debug.Log("파괴");
        }
    }


}
