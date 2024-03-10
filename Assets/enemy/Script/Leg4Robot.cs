using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leg4Robot : MonoBehaviour
{
    public Animator Reg4=null;

    public AudioSource Leg4Bullet;

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

    public NavMeshAgent navMeshAgent;
    
        void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(!Die){
            if(Z){
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
                }
            }

            if(FistMoving){
                if (navMeshAgent.remainingDistance>0&&navMeshAgent.remainingDistance < 0.1f)
                {
                    Reg4.Play("4legRobot_IDLE", 0, 0.0f);
                    FistMoving=false;
                }
            }

            if(Hp<=0){
                Die=true;
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
        StartCoroutine(ExecuteAfterDelay(5.0f));
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
        }
    }

}
