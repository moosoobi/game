using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    public enum QuestState { Inactive, Active, Completed, TurnedIn }
    public QuestState currentState = QuestState.Inactive;
    public TextMeshProUGUI Text;
    public string Description;
    public bool zzz=false;
    private void OnTriggerEnter(Collider other)
    {    
            zzz=true;
    }
    private void OnTriggerExit(Collider other)
    {    
            zzz=false;
    }
    private void Update() {
        if(zzz){
            if(Input.GetKeyDown(KeyCode.Z)){
            }
    }
    }
    
    public void AcceptQuest()
    {
        currentState=QuestState.Active;
        

    }
    public void CompleteQuest()
    {
        currentState=QuestState.Completed;
    }
}
