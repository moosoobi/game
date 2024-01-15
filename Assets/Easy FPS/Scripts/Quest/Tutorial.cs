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
            
        }
    }
}
