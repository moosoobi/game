using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingQuest : Quest
{
    public string Description;
    public int requiredShots; // 목표 발사 횟수
    public int currentShots;   // 현재 발사 횟수
    public bool zzz=false;
    public TextMeshProUGUI Text;
    QuestState CurrentState;

    public ShootingQuest(QuestState currentState)
    {
        
        requiredShots=3;
        currentShots=0;
        CurrentState=currentState;
        Description="shoot 3 bullet";
    }
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public void BulletHitTarget()
    {
        if(CurrentState==QuestState.Active){

        
            currentShots++;
          
        
            if (currentShots >= requiredShots)
            {
                CurrentState=QuestState.Completed;
                Text.text="퀘스트 완료 npc에게 돌아가십시요.";
            }
        }
    }
    
    
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    private void Update() {
        if(zzz&&Input.GetKeyDown(KeyCode.Z)){
            
            if(CurrentState==QuestState.Completed){
                Text.text="new quest";
            }
            if(CurrentState==QuestState.Inactive){
                CurrentState=QuestState.Active;
            }
            
        }
        if(CurrentState==QuestState.Active){
            Text.text=Description;
        }
    }
}
