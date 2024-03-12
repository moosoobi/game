using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leg4Robot : MonoBehaviour
{
    public Animator Reg4=null;

    public AudioSource Leg4Bullet;
    public AudioSource EnemyHittingSound;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPlace;
    private GameObject bullet;
    private GameObject bullet1;
    private GameObject bullet2;
    
    public int damage=10;
    public int Hp=5;

    public float CoolTime=3.0f;
    public float AttackRange=10.0f;
    public float DetectRange=20.0f;
    public float rotationSpeed = 5f;
    public float raycastDistance = 20f;

    public bool Attack=false;
    public bool IfWalking=false;
    public bool IfAttacking=false;
    public bool IfIdle=false;
    public bool Z=false;
    public bool first=false;
    public bool FistMoving=false;
    public bool Die=false;

    public string Walk;
    public string Shoot;

    public GameObject player;
    private Transform a;

    public LayerMask obstacleLayer; 
    public NavMeshAgent navMeshAgent;

    public EnemyDeath EnemyDeath;

    
        void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Debug.DrawRay(transform.position+Vector3.up *0.5f, player.transform.position- transform.position, Color.green);
        if(!Die){
            if(Z){
                if(Vector3.Distance(transform.position, player.transform.position)<DetectRange){
                    Vector3 playerToEnemy = player.transform.position - transform.position;
                    Vector3 playerForward = transform.forward;
                    float angle = Vector3.Angle(playerForward, playerToEnemy);
                    //Debug.Log(angle);
                    if(angle < 30f){
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position+Vector3.up *0.5f, player.transform.position- transform.position, out hit, raycastDistance,~obstacleLayer))
                        {
                            Debug.Log(1);
                            Debug.Log(hit.collider.gameObject.name);
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
                /*
                if(Vector3.Distance(transform.position, player.transform.position)<AttackRange){
                    if(!IfAttacking){Attacking();IfAttacking=true;}
                    StartCoroutine(ExecuteAfterDelayCoolTime(CoolTime));
                    CoolTime=0;
                }else if(AttackRange<Vector3.Distance(transform.position, player.transform.position)&&Vector3.Distance(transform.position, player.transform.position)<DetectRange){
                    if(!IfWalking){Walking();IfWalking=true;}
                    navMeshAgent.SetDestination(player.transform.position);
                }else{
                    navMeshAgent.isStopped = true;
                    if(!IfIdle){Idle();IfIdle=true;}
                }*/
            }

            if(FistMoving){
                if (navMeshAgent.remainingDistance>0&&navMeshAgent.remainingDistance < 0.1f)
                {
                    Reg4.Play("4legRobot_IDLE", 0, 0.0f);
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
                EnemyDeath.Death();
                gameObject.SetActive(false);
            }
        }
        
    }

    public void SetDestination(Transform targetDestination)
    {
        navMeshAgent.SetDestination(targetDestination.position);
        Reg4.Play(Walk, 0, 0.0f);
        FistMoving=true;
    }
    public void Active(){
        Z=true;
    }
    private void Walking(){
        
        Reg4.Play(Walk, 0, 0.0f);
        navMeshAgent.isStopped = false;
        IfIdle=false;
        IfAttacking=false;
    }
    private void Attacking(){
        navMeshAgent.isStopped = true;
        Z=false;
        Reg4.Play(Shoot, 0, 0.0f);
        StartCoroutine(Shooting());
        StartCoroutine(ExecuteAfterDelay(3.0f));
        IfWalking=false;
    }
    private void Idle(){
       
        Reg4.Play("4legRobot_IDLE", 0, 0.0f);
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
    private IEnumerator Shooting()
    {
        Vector3 playerDirection = (player.transform.position - bulletSpawnPlace.transform.position).normalized;
        bullet = Instantiate(bulletPrefab, bulletSpawnPlace.transform.position, bulletSpawnPlace.transform.rotation);
        bullet.transform.right = playerDirection;
        Leg4Bullet.Play();
        yield return new WaitForSeconds(0.4f);
        bullet1 = Instantiate(bulletPrefab, bulletSpawnPlace.transform.position, bulletSpawnPlace.transform.rotation);
        bullet1.transform.right = playerDirection;
        Leg4Bullet.Play();
        yield return new WaitForSeconds(0.4f);
        bullet2 = Instantiate(bulletPrefab, bulletSpawnPlace.transform.position, bulletSpawnPlace.transform.rotation);
        bullet2.transform.right = playerDirection;
        Leg4Bullet.Play();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            Hp-=1;
            EnemyHittingSound.Play();
        }
    }

}
