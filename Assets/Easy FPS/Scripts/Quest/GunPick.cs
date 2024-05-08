using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunPick : Quest
{
    public string Description;
    public bool zzz=false;
    public bool pick=false;
    public bool Clear=false;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI QuestText;
    public QuestState CurrentState;
    public ShootingQuest shootingquest;
    public DialogueManager dia;
    public AudioSource QuestSound;
    public GunInventory guninventory;
    public pick pickS;
    

    public GunPick(QuestState currentState)
    {
        CurrentState=currentState;
    }
    
    void Awake()
    {
        Description="본부 내부를 조사하여 총을 획득하십시오.";
    }
    public void pickup(){
        if(CurrentState==QuestState.Active){
            CurrentState=QuestState.Completed;
            shootingquest.Active();
            shootingquest.QuestActive();
        }
        
    }
    public bool ifpick(){return CurrentState==QuestState.Completed;}
    void Update()
    {
        
        if(zzz&&Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
            
            
            if(CurrentState==QuestState.Inactive){
                CurrentState=QuestState.Active;
            }
            
        }
        
    
    }
    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
        QuestSound.Play();
        Clear=true;
        pickS.Clear=true;
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(Clear){
            zzz=true;
        }
        
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }


}
