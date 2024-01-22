using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunPick : Quest
{
    public string Description;
    public bool zzz=false;
    public bool pick=false;
    public TextMeshProUGUI Text;
    QuestState CurrentState;
    public ShootingQuest shootingquest;

    public GunPick(QuestState currentState)
    {
        
        
        CurrentState=currentState;
        
    }
    
    void Awake()
    {
        CurrentState=QuestState.Active;
        Description="책상에 있는 총을 획득하십시오.";
        shootingquest=GetComponent<ShootingQuest>();
    }
    public void pickup(){
        if(CurrentState==QuestState.Active){
            CurrentState=QuestState.Completed;
        }
        
    }
    
    void Update()
    {
        if(zzz&&Input.GetKeyDown(KeyCode.Z)){
            
            if(CurrentState==QuestState.Completed){
                Text.text="총을 꺼내 마네킹을 사격하십시오.";
                shootingquest.currentState=QuestState.Active;
            }
            if(CurrentState==QuestState.Inactive){
                
                CurrentState=QuestState.Active;
                
            }
            
        }
        if(CurrentState==QuestState.Active){
            Text.text=Description;
        }
    
    }

    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
}
