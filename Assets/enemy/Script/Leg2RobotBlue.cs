using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leg2RobotBlue : MonoBehaviour
{
    public Animator Blue=null;

    
    public float CoolTime=3.0f;
    public float rotationSpeed = 5f;
    public float AttackRange=3.0f;
    public float DetectRange=10.0f;

    public bool Attack=false;
    public bool IfWalking=false;
    public bool IfAttacking=false;
    public bool IfIdle=false;
    public bool Z=true;

    public string Walk;
    public string Slash;

    public Transform player;

    public NavMeshAgent navMeshAgent;
    


    void Update()
    {
        if(Z){
            if(Vector3.Distance(transform.position, player.position)<AttackRange){
                if(!IfAttacking){Attacking();IfAttacking=true;}
                StartCoroutine(ExecuteAfterDelayCoolTime(CoolTime));
                CoolTime=0;
            }else if(AttackRange<Vector3.Distance(transform.position, player.position)&&Vector3.Distance(transform.position, player.position)<DetectRange){
                if(!IfWalking){Walking();IfWalking=true;}
                navMeshAgent.SetDestination(player.position);
            }else{
                navMeshAgent.isStopped = true;
                if(!IfIdle){Idle();IfIdle=true;}
            }
        }
        
        
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

    private void Walking(){
        Blue.Play(Walk, 0, 0.0f);
        navMeshAgent.isStopped = false;
        IfIdle=false;
        IfAttacking=false;
    }
    private void Attacking(){
        Blue.Play(Slash, 0, 0.0f);
        navMeshAgent.isStopped = true;
        Z=false;
        StartCoroutine(ExecuteAfterDelay(5.0f));
        IfWalking=false;
    }
    private void Idle(){
        Blue.Play("Idle", 0, 0.0f);
        IfWalking=false;
        IfAttacking=false;
    }

    private IEnumerator ExecuteAfterDelayCoolTime(float delayInSeconds)
    {
        
        yield return new WaitForSeconds(delayInSeconds);
        CoolTime=3.0f;
        
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        
        yield return new WaitForSeconds(delayInSeconds);
        Z=true;
        
    }


}
