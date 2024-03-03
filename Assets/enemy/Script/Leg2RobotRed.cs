using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Leg2RobotRed : MonoBehaviour
{
    public Animator Red=null;

    
    public float CoolTime=3.0f;
    public float rotationSpeed = 5f;
    public float AttackRange=10.0f;
    public float DetectRange=20.0f;

    public bool Attack=false;
    public bool IfWalking=false;
    public bool IfAttacking=false;
    public bool IfIdle=false;
    public bool Z=true;

    public string Walk;
    public string Shoot;

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
    }


    private void Walking(){
        Red.Play(Walk, 0, 0.0f);
        navMeshAgent.isStopped = false;
        IfIdle=false;
        IfAttacking=false;
    }
    private void Attacking(){
        Red.Play(Shoot, 0, 0.0f);
        navMeshAgent.isStopped = true;
        Z=false;
        StartCoroutine(ExecuteAfterDelay(5.0f));
        IfWalking=false;
    }
    private void Idle(){
        Red.Play("Rifle Aiming Idle", 0, 0.0f);
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
