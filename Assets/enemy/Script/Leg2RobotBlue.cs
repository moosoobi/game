using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg2RobotBlue : MonoBehaviour
{

    public int CoolTime=3;

    public float rotationSpeed = 5f;
    public float AttackRange=3.0f;
    public float moveSpeed=3.0f;

    public bool Attack=false;
    
    public Transform player;

    
    void Update()
    {
        if(Attack){
            if (player != null)
                {
                    // 적과 플레이어 사이의 방향 벡터 계산
                    Vector3 directionToPlayer = player.position - transform.position;
                    directionToPlayer.y = 0f; // Y축 방향은 무시 (수평 방향으로만 회전)

                    // 방향 벡터를 바탕으로 회전 값 생성
                    Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                    // 적의 회전을 부드럽게 설정
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }  
        }
    }

    private void Moving(){
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f; // Y 축 방향은 무시
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void Attacking(){

    }

    private IEnumerator ExecuteAfterDelayCoolTime(float delayInSeconds)
    {
        
        yield return new WaitForSeconds(delayInSeconds);
        
    }
}
