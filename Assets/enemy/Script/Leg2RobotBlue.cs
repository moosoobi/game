using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leg2RobotBlue : MonoBehaviour
{
    public Animator Blue=null;

    public AudioSource BlueSword;
    public AudioSource EnemyHittingSound;

    
    public int Hp=5;

    public float CoolTime=3.0f;
    public float rotationSpeed = 5f;
    public float AttackRange=3.0f;
    public float DetectRange=10.0f;
    public float raycastDistance = 20f;

    public bool Attack=false;
    public bool IfWalking=false;
    public bool IfAttacking=false;
    public bool IfIdle=false;
    public bool Z=false;
    public bool FistMoving=false;
    public bool Die=false;
    public bool back=true;
    public bool Ifhit=false;
    public bool IfChip=false;

    public string Walk;
    public string Slash;

    public GameObject player;
    public GameObject PlayerForward;
    public GameObject Chip;

    public Transform RespawnSpot;

    public NavMeshAgent navMeshAgent;

    public LayerMask obstacleLayer; 
    
    public EnemyDeath EnemyDeath;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        
        if(!Die){
            if(Z){
                if(Ifhit){
                     if(Vector3.Distance(transform.position, player.transform.position)<AttackRange){
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position+Vector3.up *0.5f, player.transform.position- transform.position, out hit, raycastDistance,~obstacleLayer))
                        {
                            //Debug.Log(hit.collider.gameObject.name);
                            if(hit.collider.gameObject.name=="Player"){if(!IfAttacking){Attacking();IfAttacking=true;}}
                            else{if(!IfWalking){Walking();IfWalking=true;}
                                    navMeshAgent.SetDestination(player.transform.position);}   
                        }
                     }else{if(!IfWalking){Walking();IfWalking=true;}
                                    navMeshAgent.SetDestination(player.transform.position);}
                }
                else if(Vector3.Distance(transform.position, player.transform.position)<AttackRange){
                    Vector3 directionToPlayer = player.transform.position - transform.position;
                    directionToPlayer.y = 0f; // Y축 방향은 무시 (수평 방향으로만 회전)
                    // 방향 벡터를 바탕으로 회전 값 생성
                    Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                    // 적의 회전을 부드럽게 설정
                    transform.rotation = targetRotation;
                    RaycastHit hit;
                        if (Physics.Raycast(transform.position+Vector3.up *0.5f, player.transform.position- transform.position, out hit, raycastDistance,~obstacleLayer))
                        {
                            //Debug.Log(hit.collider.gameObject.name);
                            if(hit.collider.gameObject.name=="Player"){if(!IfAttacking){Attacking();IfAttacking=true;}}
                        }
                                
                }else if(Vector3.Distance(transform.position, player.transform.position)<DetectRange||Ifhit){
                    Vector3 playerToEnemy = player.transform.position - transform.position;
                    Vector3 playerForward = transform.forward;
                    float angle = Vector3.Angle(playerForward, playerToEnemy);
                    //Debug.Log(angle);
                    if(angle < 120f||Ifhit){
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position+Vector3.up *0.5f, player.transform.position- transform.position, out hit, raycastDistance,~obstacleLayer))
                        {
                            //Debug.Log(hit.collider.gameObject.name);
                            if(hit.collider.gameObject.name=="Player"||Ifhit){
                                if(Vector3.Distance(transform.position, player.transform.position)<DetectRange||Ifhit){
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
                    transform.rotation = targetRotation;
                    
                }
            }
            
            if(Hp<=0){
                Die=true;
                StartCoroutine(Death());
                navMeshAgent.isStopped = true;
                
            }
        }
        

    }


    public void Active(){
        Z=true;
    }
    public void SetDestination(Transform targetDestination)
    {
        navMeshAgent.isStopped = false;
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
        StartCoroutine(ExecuteAfterDelay(1.0f));
        IfWalking=false;
        player.GetComponent<PlayerHp>().UpdateHealth(-30f);
    }
    private void Idle(){
        Blue.Play("Great Sword Idle", 0, 0.0f);
        IfWalking=false;
        IfAttacking=false;
    }
    public void Respawn(){
        gameObject.SetActive(true);
        navMeshAgent.isStopped = true;
        Attack=false;
        IfWalking=false;
        IfAttacking=false;
        IfIdle=false;
        Ifhit=false;
        Z=false;
        FistMoving=false;
        Die=false;
        back=true;
        Blue.Play("Great Sword Idle", 0, 0.0f);
        Hp=5;
        transform.position=RespawnSpot.position;
        transform.rotation=RespawnSpot.rotation;
        StartCoroutine(RespawnSpotMove());
    }
    private IEnumerator RespawnSpotMove(){
        yield return new WaitForSeconds(0.5f);
        transform.position=RespawnSpot.position;
        transform.rotation=RespawnSpot.rotation;
    }
    private IEnumerator ExecuteAfterDelayCoolTime(float delayInSeconds)
    {
        
        yield return new WaitForSeconds(delayInSeconds);
        CoolTime=3.0f;
        IfAttacking=false;
        
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        
        yield return new WaitForSeconds(delayInSeconds);
        Z=true;
        IfAttacking=false;
        
    }
    private IEnumerator Death()
    {
        Blue.Play("Two Handed Sword Death", 0, 0.0f);
        EnemyDeath.Death();
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        Quaternion newRotation = Quaternion.Euler(-90f, 0f, 0f); // 회전값 설정 (x축으로 -90도 회전)
        if(IfChip){Instantiate(Chip, transform.position, newRotation);}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            Hp-=1;
            EnemyHittingSound.Play();
            Ifhit=true;
            
        }
    }
}
