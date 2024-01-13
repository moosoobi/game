using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int requiredShots = 5;  // 목표 발사 횟수
    private int currentShots = 0;  // 현재 발사 횟수


    
    // 총알이 목표에 맞았을 때 호출되는 메서드
    public void BulletHitTarget()
    {
        currentShots++;
        Debug.Log("1");
        // 퀘스트 완료 체크
        if (currentShots >= requiredShots)
        {
            CompleteQuest();
        }
    }

    // 퀘스트 완료 시 호출되는 메서드
    private void CompleteQuest()
    {
        Debug.Log("Quest Complete! You've shot the target " + requiredShots + " times.");
        // 여기서 보상을 부여하거나 다른 작업을 수행할 수 있습니다.
    }
}
