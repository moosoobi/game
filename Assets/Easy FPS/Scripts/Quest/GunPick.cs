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
    public TextMeshProUGUI QuestText;
    public QuestState CurrentState;
    public ShootingQuest shootingquest;
    public GameObject text1;
    public DialogueManager dia;
    

    public GunPick(QuestState currentState)
    {
        CurrentState=currentState;
    }
    
    void Awake()
    {
        Description="방안을 조사해 총을 획득하십시오.";
        dia=GetComponent<DialogueManager>();
        shootingquest=GetComponent<ShootingQuest>();
    }
    public void pickup(){
        if(CurrentState==QuestState.Active){
            Debug.Log(1);
            CurrentState=QuestState.Completed;
            shootingquest.Active();
            text1.SetActive(true);
            shootingquest.QuestActive();
            StartCoroutine(ExecuteAfterDelay(3f));
        }
        
    }
    public bool ifpick(){return CurrentState==QuestState.Completed;}
    void Update()
    {
        
        if(zzz&&Input.GetKeyDown(KeyCode.Z)){
            
            
            if(CurrentState==QuestState.Inactive){
                CurrentState=QuestState.Active;
            }
            
        }

        
    
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

    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        text1.SetActive(false);
    }

}
