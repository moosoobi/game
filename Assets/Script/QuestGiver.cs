using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest Quest;
    public TextMeshProUGUI Text;
    string description;
    public bool zzz=false;
    private void Awake() {
        description=Quest.Description;
    }
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
                Quest.AcceptQuest();
                Text.text=description;
            }
    }
    }
}
