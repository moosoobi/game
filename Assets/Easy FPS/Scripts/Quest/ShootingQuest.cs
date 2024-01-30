using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingQuest : Quest
{
    public string Description;
    public int requiredShots;
    public int currentShots;  
    public bool zzz=false;
    public TextMeshProUGUI Text;
    public QuestState CurrentState;
    public TextMeshProUGUI QuestText;
    public DialogueManager dia;
    
    
    public ShootingQuest(QuestState currentState)
    {
        
    
        CurrentState=currentState;
        
    }
    
    void Awake()
    {
        dia=GetComponent<DialogueManager>();
        Description="마네킹을 3회 사격하십시오";
        requiredShots=3;
        currentShots=0;
    }
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public void BulletHitTarget()
    {
        if(CurrentState==QuestState.Active){

        
            currentShots++;
          
        
            if (currentShots >= requiredShots)
            {
                dia.upstage();
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
                    Text.text="방안에 서랍을 열어 지도를 획득하시오.";
                }
                
            
            }

        
        
    }
    public void Active(){
        CurrentState=QuestState.Active;
    }
    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
