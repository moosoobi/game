using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leg2RobotBlue : MonoBehaviour
{
    public Animator Blue=null;

    public AudioSource BlueSword;
    
    public int Hp=5;

    public float CoolTime=3.0f;
    public float rotationSpeed = 5f;
    public float AttackRange=3.0f;
    public float DetectRange=10.0f;
    public float raycastDistance = 10f;

    public bool Attack=false;
    public bool IfWalking=false;
    public bool IfAttacking=false;
    public bool IfIdle=false;
    public bool Z=false;
    public bool FistMoving=false;
    public bool Die=false;
    public bool back=true;

    public string Walk;
    public string Slash;

    public GameObject player;
    public GameObject PlayerForward;

    public Transform Destination;

    public EnemyArea Area1;
    public EnemyArea Area2;

    public NavMeshAgent navMeshAgent;

    public LayerMask obstacleLayer; 
    

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        
        if(!Die){
            if(Z){
                if(Vector3.Distance(transform.position, player.transform.position)<DetectRange){
                    Vector3 playerToEnemy = transform.position - player.transform.position;
                    Vector3 playerForward = player.transform.forward;
                    float angle = Vector3.Angle(playerForward, playerToEnemy);
                    //Debug.Log(angle);
                    if(angle < 30f){
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position+Vector3.up *0.5f, player.transform.position- transform.position, out hit, raycastDistance,~obstacleLayer))
                        {
                            //Debug.Log(hit.collider.gameObject.name);
                            if(hit.collider.gameObject.name=="Player"){
                                if(Vector3.Distance(transform.position, player.transform.position)<AttackRange){
                                if(!IfAttacking){Attacking();IfAttacking=true;}
                                StartCoroutine(ExecuteAfterDelayCoolTime(CoolTime));
                                CoolTime=0;
                                }else if(AttackRange<Vector3.Distance(transform.position, player.transform.position)&&Vector3.Distance(transform.position, player.transform.position)<DetectRange){
                                    if(!IfWalking){Walking();IfWalking=true;}
                                    navMeshAgent.SetDestination(player.transform.position);
                                }else{
                                    if (navMeshAgent.isActiveAndEnabled && navMeshAgent.isOnNavMesh)
                                    {
                                        navMeshAgent.isStopped = true;
                                    }

                                    if(!IfIdle){Idle();IfIdle=true;}
                                }
                            }
                        }
                    }else{
                        if (navMeshAgent.isActiveAndEnabled && navMeshAgent.isOnNavMesh)
                        {
                            navMeshAgent.isStopped = true;
                        }

                        if(!IfIdle){Idle();IfIdle=true;}
                    }
                
            }
 
        }
            if(FistMoving){
                if (navMeshAgent.remainingDistance>0&&navMeshAgent.remainingDistance < 0.1f)
                {
                    Blue.Play("Great Sword Idle", 0, 0.0f);
                    FistMoving=false;
                    Z=true;
                    Vector3 directionToPlayer = player.transform.position - transform.position;
                    directionToPlayer.y = 0f; // Y축 방향은 무시 (수평 방향으로만 회전)

                    // 방향 벡터를 바탕으로 회전 값 생성
                    Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                    // 적의 회전을 부드럽게 설정
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    
                }
            }
            
            if(Hp<=0){
                Die=true;
                StartCoroutine(Death());
            }
        }
        

    }

    public void Active(){
        Z=true;
    }
    public void SetDestination(Transform targetDestination)
    {
        navMeshAgent.SetDestination(targetDestination.position);
        Blue.Play(Walk, 0, 0.0f);
        FistMoving=true;
    }
    private void Walking(){
        Blue.Play(Walk, 0, 0.0f);
        navMeshAgent.isStopped = false;
        IfIdle=false;
        IfAttacking=false;
    }
    private void Attacking(){
        BlueSword.Play();
        Blue.Play(Slash, 0, 0.0f);
        navMeshAgent.isStopped = true;
        Z=false;
        StartCoroutine(ExecuteAfterDelay(3.0f));
        IfWalking=false;
        player.GetComponent<PlayerHp>().UpdateHealth(-30f);
    }
    private void Idle(){
        Blue.Play("Great Sword Idle", 0, 0.0f);
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
    private IEnumerator Death()
    {
        Blue.Play("Two Handed Sword Death", 0, 0.0f);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            Hp-=1;
        }
    }
}
