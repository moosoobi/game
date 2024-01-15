using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial : Quest
{

    public string Description{get;set;}
    public int requiredShots{get;set;} // 목표 발사 횟수
    private int currentShots {get;set;}  // 현재 발사 횟수
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public Tutorial(QuestState currentState, string description)
    {
        
        requiredShots=5;
        currentShots=0;
        QuestState CurrentState=currentState;
        string Description=description;
    }
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public void BulletHitTarget()
    {
        currentShots++;
        Debug.Log("1");
        // 퀘스트 완료 체크
        if (currentShots >= requiredShots)
        {
            
        }
    }
    private void Update() {
        
    }
}
