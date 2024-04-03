using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class RealBoss : MonoBehaviour
{
    
    public TextMeshProUGUI text1;
    public GameObject Text1;
    private int currentPatternIndex = 0; // 현재 실행 중인 공격 패턴 인덱스
    private bool isAttacking = false; // 현재 공격 중인지 여부
    public float duration=5f;
    public int AttackLength=3;
    public GameObject player;
    public GameObject Lazer;
    public GameObject BlackScreen;
    public GameObject Monitor;
    public AudioSource electricsound;
    public AudioSource lazersound;
    public AudioSource warningsound;
    public GameObject[] Bullet;
    public float obstacleSpeed = 5f;  // 장애물 이동 속도
    public int numberOfWaves = 5;
    private bool alive=true;
    private bool touch=false;
    public VideoPlayer Loading;
    public GameObject[] Screen;
    public Material Blue;
    public Material Yellow;
    public Material Pink;
    

    private void Start()
    {
        
        Loading.loopPointReached += OnVideoEnd;
    }


    void Update()
    {
        if(touch){
            if(alive){
                if (!isAttacking)
                {
                    // 현재 공격 패턴 실행
                    StartCoroutine(ExecuteAttackPattern());
                }
        }
        }
        
        
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        BlackScreen.SetActive(false);
        Monitor.SetActive(false);
        Renderer rend1 = Screen[0].GetComponent<Renderer>();
        rend1.material = Blue;
        Renderer rend2 = Screen[1].GetComponent<Renderer>();
        rend1.material = Yellow;
        Renderer rend3 = Screen[2].GetComponent<Renderer>();
        rend1.material = Pink;
        StartConversation();
    }

    public void touchboss(){
        //touch=true;
        if(warningsound){warningsound.Play();}
        BlackScreen.SetActive(true);
        Monitor.SetActive(true);
        Loading.Play();


    }
    public void die(){
        alive=false;
        Text1.SetActive(true);
        text1.text="해치웠다. 가서 해킹칩을 심자.";
        StartCoroutine(ExecuteAfterDelayText(3f));
    }
    IEnumerator ExecuteAttackPattern()
    {
        isAttacking = true;

        // 현재 공격 패턴 실행
        if (currentPatternIndex < AttackLength)
        {
            

            // 공격 패턴 실행
            yield return StartCoroutine(Execute(currentPatternIndex));

            // 다음 패턴으로 이동
            currentPatternIndex++;
        }
        else
        {
            // 모든 패턴이 실행된 경우 초기화 또는 다른 동작 수행
            // 예: currentPatternIndex를 0으로 초기화
            currentPatternIndex = 0;
        }

        isAttacking = false;
    }

    

    public void LazerAttack(){
        Vector3 lazerposition=new Vector3(transform.position.x-23f, transform.position.y-5f, transform.position.z-7f);
        GameObject lazerobject = Instantiate(Lazer,lazerposition , Quaternion.identity);
        lazersound.Play();
        Rigidbody lazerRd = lazerobject.GetComponent<Rigidbody>();
        if (lazerRd != null)
        {
            lazerRd.velocity = new Vector3(10f, 0.0f, 0.0f);
        }
    }

    void BulletAttack(){
        

        int randomValue = GetRandomNumber(0, 3);
        Vector3 position=new Vector3(transform.position.x, transform.position.y, transform.position.z+5f);
        // 장애물 생성
        GameObject obstacle = Instantiate(Bullet[randomValue],position , Quaternion.identity);
        electricsound.Play();

        // 장애물에 힘을 가해 발사
        Rigidbody obstacleRb = obstacle.GetComponent<Rigidbody>();
        if (obstacleRb != null)
        {
            
            obstacleRb.velocity = new Vector3(0.0f, 0.0f, -obstacleSpeed);
        }
        
    }
    int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    

    public IEnumerator Execute(int currentPatternIndex)
    {   
        yield return new WaitForSeconds(duration);
        if(currentPatternIndex==1){
            Text1.SetActive(true);
            text1.text="레이저 공격 준비!";
            StartCoroutine(ExecuteAfterDelayText(3f));
            LazerAttack();
            yield return new WaitForSeconds(duration);
        }else if(currentPatternIndex==2){
            Text1.SetActive(true);
            text1.text="에너지볼 공격!";
            StartCoroutine(ExecuteAfterDelayText(3f));
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 6f);

            yield return new WaitForSeconds(20f);
        }
    }
    void StopSpawningObstacles()
    {
        // 일정 시간이 지나면 장애물 생성을 멈춥니다.
        CancelInvoke("BulletAttack");
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        Text1.SetActive(false);
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        
    }
    
    

}
