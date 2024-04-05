using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.UI;

public class RealBoss : MonoBehaviour
{
    public Animator BossAni;
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
    public GameObject BossBulletSpawn;
    public GameObject BossBullet;
    public GameObject Red;
    public GameObject Leg2Blue;
    public GameObject Leg4;
    public GameObject FixingDrone;
    public GameObject SectorA;
    public GameObject SectorB;
    public GameObject SectorC;
    public AudioSource electricsound;
    public AudioSource lazersound;
    public AudioSource warningsound;
    private bool alive=true;
    private bool touch=false;
    public VideoPlayer Loading;
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject TimerCamera;
    public GameObject FixingCamera;
    public Material Blue;
    public Material Yellow;
    public Material Pink;
    public Material Error1;
    public Material Error2;
    public Material Black;
    public TextMeshProUGUI Text;
    public string Description;
    public TextMeshProUGUI QuestText;
    public AudioSource RadioSound;
    public string[] dialogue;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool zzz=false;
    public bool clear=false;
    public bool first=true;
    public float BossHp=100f;
    public float BossMaxHp=100f;
    public Slider BossSlider;
    public GameObject BossText;
    public Light light;
    private float temp;
    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;
    private Coroutine currentCoroutine;
    public int Fixing=0;
    public bool Under50=false;
    public bool Under30=false;

    private void Start()
    {
        Loading.loopPointReached += OnVideoEnd;
        rend1 = Screen1.GetComponent<Renderer>();//left
        rend2 = Screen2.GetComponent<Renderer>();//right
        rend3 = Screen3.GetComponent<Renderer>();//main
        
         
    }


    void Update()
    {
        
        if(touch){
            if(alive){
                Vector3 directionToPlayer = player.transform.position - transform.position;
                directionToPlayer.y = 0f; // Y축 방향은 무시 (수평 방향으로만 회전)
                // 방향 벡터를 바탕으로 회전 값 생성
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                Vector3 euler = targetRotation.eulerAngles;
                euler.x = -90f; // x 값을 -90도로 설정
                euler.z += -40f; // z 값을 -40만큼 추가로 회전
                targetRotation = Quaternion.Euler(euler);
                transform.rotation = targetRotation;
                if (!isAttacking)
                {
                    // 현재 공격 패턴 실행
                    currentCoroutine = StartCoroutine(ExecuteAttackPattern());
                }
        }
        }
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
                
            ContinueConversation();          
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
            EndDialogue();
        }
        
        
    }

    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        BlackScreen.SetActive(false);
        Monitor.SetActive(false);
        rend1.material = Blue;
        rend2.material = Yellow;
        rend3.material = Pink;
        StartConversation();
    }

    public void touchboss(){
        
        if(warningsound){warningsound.Play();}
        BlackScreen.SetActive(true);
        Monitor.SetActive(true);
        Loading.Play();
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().currentSpeed = 0;
        player.GetComponent<PlayerMovementScript>().enabled = false;


    }
    public void die(){
        alive=false;
        Text1.SetActive(true);
        text1.text="해치웠다. 가서 해킹칩을 심자.";
        StartCoroutine(ExecuteAfterDelayText(3f));
    }
    public void StartConversation(){
        RadioSound.Play();
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text=dialogue[0];
        zzz=false;
        


    }

    public void ContinueConversation(){
            curResponseTracker++;
            if(curResponseTracker>dialogue.Length){
                curResponseTracker=dialogue.Length;
            }
            else if(curResponseTracker<dialogue.Length)
            {
                npcDialogueBox.text=dialogue[curResponseTracker];
            }
    }

    public void EndDialogue(){
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        QuestActive();
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        clear=true;
    }
    IEnumerator ExecuteAttackPattern()
    {
        isAttacking = true;

        
        if (currentPatternIndex < AttackLength)
        {
            // 공격 패턴 실행
            yield return StartCoroutine(Execute(currentPatternIndex));
            // 다음 패턴으로 이동
            currentPatternIndex++;
        }
        else
        {
            if(!Under30){
                int randomValue = GetRandomNumber(3, 6);
                yield return StartCoroutine(Execute(randomValue));
            }else{
                int randomValue = GetRandomNumber(7, 10);
                yield return StartCoroutine(Execute(randomValue));
            }
            
        }

        isAttacking = false;
    }

    

    public void LazerAttack(){
        Lazer.SetActive(true);
        Invoke("DeactivateAfterDelay", 10.0f);
    }
    void DeactivateAfterDelay()
    {
        Lazer.SetActive(false);
    }
    void BulletAttack(){
        Vector3 playerDirection = (player.transform.position - BossBulletSpawn.transform.position).normalized;
        GameObject bullet = Instantiate(BossBullet, BossBulletSpawn.transform.position, BossBulletSpawn.transform.rotation);
        bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bullet.transform.forward = playerDirection;
        electricsound.Play();

        
        
    }
    public void FightRobot(){
        GameObject Enemy1 = Instantiate(Leg4,SectorB.transform.position , SectorB.transform.rotation);
        GameObject Enemy2 = Instantiate(Red,SectorC.transform.position , SectorC.transform.rotation);

       Enemy1.GetComponent<Leg4Robot>().Ifhit=true;
       Enemy2.GetComponent<Leg2RobotRed>().Ifhit=true;
        
    }
    public void FightRobot2(){
        GameObject Enemy1 = Instantiate(Leg4,SectorB.transform.position , SectorB.transform.rotation);
        GameObject Enemy2 = Instantiate(Red,SectorC.transform.position , SectorC.transform.rotation);
        GameObject Enemy3 = Instantiate(Leg2Blue,SectorA.transform.position , SectorA.transform.rotation);

       Enemy1.GetComponent<Leg4Robot>().Ifhit=true;
       Enemy2.GetComponent<Leg2RobotRed>().Ifhit=true;
       Enemy3.GetComponent<Leg2RobotBlue>().Ifhit=true;
        
    }
    public void FixingRobot(){
        GameObject Fixing1 = Instantiate(FixingDrone,SectorA.transform.position+new Vector3(0,6,10) , SectorA.transform.rotation);
        GameObject Fixing2 = Instantiate(FixingDrone,SectorA.transform.position+new Vector3(0,6,0) , SectorA.transform.rotation);
        GameObject Fixing3 = Instantiate(FixingDrone,SectorA.transform.position+new Vector3(0,6,-10) , SectorA.transform.rotation);
        GameObject Fixing4 = Instantiate(FixingDrone,SectorB.transform.position+new Vector3(10,6,-5) , SectorB.transform.rotation);
        GameObject Fixing5 = Instantiate(FixingDrone,SectorB.transform.position+new Vector3(0,6,0) , SectorB.transform.rotation);
        GameObject Fixing6 = Instantiate(FixingDrone,SectorB.transform.position+new Vector3(-10,6,5) , SectorB.transform.rotation);
        GameObject Fixing7 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(10,6,5) , SectorC.transform.rotation);
        GameObject Fixing8 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(0,6,0) , SectorC.transform.rotation);
        GameObject Fixing9 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(-10,6,-5) , SectorC.transform.rotation);
        GameObject Fixing10 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(-15,6,-10) , SectorC.transform.rotation);
        
        
    }
    int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    

    public IEnumerator Execute(int currentPatternIndex)
    {   
        
        if(currentPatternIndex==0){
            Text1.SetActive(true);
            text1.text=" 메인 컴퓨터가 바닥을 훑는 레이저를 발사합니다.";
            rend2.material = Yellow;
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ExecuteAfterDelayText(3f));
            LazerAttack();
            yield return new WaitForSeconds(10.0f);
            rend2.material=Black;
        }else if(currentPatternIndex==1){
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 강력한 에너지볼을 방출합니다.";
            rend1.material=Blue;
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ExecuteAfterDelayText(3f));
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 1f);
            
            yield return new WaitForSeconds(18f);
            rend1.material=Black;
        }else if(currentPatternIndex==2){
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 전투로봇을 호출합니다.";
            rend3.material=Pink;
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ExecuteAfterDelayText(3f));
            FightRobot();
            yield return new WaitForSeconds(10.0f);
            rend3.material=Black;
        }else if(currentPatternIndex==3){
            rend2.material = Yellow;
            yield return new WaitForSeconds(3.0f);
            LazerAttack();
            yield return new WaitForSeconds(10.0f);
            rend2.material=Black;
        }else if(currentPatternIndex==4){
            rend1.material=Blue;
            yield return new WaitForSeconds(3.0f);
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 3f);
            yield return new WaitForSeconds(18f);
            rend1.material=Black;
        }else if(currentPatternIndex==5){
            rend3.material=Pink;
            yield return new WaitForSeconds(3.0f);
            FightRobot();
            yield return new WaitForSeconds(10.0f);
            rend3.material=Black;
        }
        else if(currentPatternIndex==6){
            Fixing=0;
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 수리 로봇을 호출합니다. 파괴하여 수리를 중단해야 합니다.";
            StartCoroutine(ExecuteAfterDelayText(3f));
            yield return new WaitForSeconds(3.0f);
            TimerCamera.SetActive(true);
            FixingCamera.SetActive(true);
            GameObject Fixing1 = Instantiate(FixingDrone,SectorA.transform.position+new Vector3(0,6,10) , SectorA.transform.rotation);
            GameObject Fixing2 = Instantiate(FixingDrone,SectorA.transform.position+new Vector3(0,6,0) , SectorA.transform.rotation);
            GameObject Fixing3 = Instantiate(FixingDrone,SectorA.transform.position+new Vector3(0,6,-10) , SectorA.transform.rotation);
            GameObject Fixing4 = Instantiate(FixingDrone,SectorB.transform.position+new Vector3(10,6,-5) , SectorB.transform.rotation);
            GameObject Fixing5 = Instantiate(FixingDrone,SectorB.transform.position+new Vector3(0,6,0) , SectorB.transform.rotation);
            GameObject Fixing6 = Instantiate(FixingDrone,SectorB.transform.position+new Vector3(-10,6,5) , SectorB.transform.rotation);
            GameObject Fixing7 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(10,6,5) , SectorC.transform.rotation);
            GameObject Fixing8 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(0,6,0) , SectorC.transform.rotation);
            GameObject Fixing9 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(-10,6,-5) , SectorC.transform.rotation);
            GameObject Fixing10 = Instantiate(FixingDrone,SectorC.transform.position+new Vector3(-15,6,-10) , SectorC.transform.rotation);
            yield return new WaitForSeconds(20.0f);
            if(Fixing1){Fixing1.SetActive(false);}
            if(Fixing2){Fixing2.SetActive(false);}
            if(Fixing3){Fixing3.SetActive(false);}
            if(Fixing4){Fixing4.SetActive(false);}
            if(Fixing5){Fixing5.SetActive(false);}
            if(Fixing6){Fixing6.SetActive(false);}
            if(Fixing7){Fixing7.SetActive(false);}
            if(Fixing8){Fixing8.SetActive(false);}
            if(Fixing9){Fixing9.SetActive(false);}
            if(Fixing10){Fixing10.SetActive(false);}
            TimerCamera.SetActive(false);
            FixingCamera.SetActive(false);
            clear=true;
            if(Fixing==10){
                Under50=true;
                Text1.SetActive(true);
                text1.text="메인 컴퓨터가 수리에 실패했습니다. 과부하로 인해 10초간 동작이 중지됩니다.";
                StartCoroutine(ExecuteAfterDelayText(10f));
                yield return new WaitForSeconds(10.0f);
                touch=true;
                
            }else{
                Text1.SetActive(true);
                text1.text="메인 컴퓨터가 수리에 성공했습니다. 많은 양의 에너지가 공급 됩니다.";
                StartCoroutine(ExecuteAfterDelayText(3f));
                touch=true;
                BossHp=70;

            }
        }else if(currentPatternIndex==7){
            
            rend2.material = Yellow;
            yield return new WaitForSeconds(3.0f);
            LazerAttack();
            Lazer.GetComponent<BossLazer>().rotationSpeed=80;
            yield return new WaitForSeconds(10.0f);
            rend2.material=Black;
        }else if(currentPatternIndex==8){
            rend1.material=Blue;
            yield return new WaitForSeconds(3.0f);
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 2f);
            
            yield return new WaitForSeconds(18f);
            rend1.material=Black;
        }else if(currentPatternIndex==9){
            rend3.material=Pink;
            yield return new WaitForSeconds(3.0f);
            FightRobot2();
            yield return new WaitForSeconds(10.0f);
            rend3.material=Black;
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
    
    void InitializeHealthBar()
    {
        // 최대 HP 설정
        BossSlider.maxValue = BossMaxHp;

        // 현재 HP 설정
        BossSlider.value = BossHp;
    }
    public void UpdateHealth(float newHP)
    {

        // 현재 HP 갱신
        BossHp += newHP;

        // 슬라이더에 반영
        BossSlider.value = BossHp;
        if(!Under50){
            if (BossHp <= 50f)
            {
                touch=false;
                StopCoroutine(currentCoroutine);
                StartCoroutine(Execute(6));
                clear=false;
                
            }
        }
        
        
        if (BossHp == 30f)
        {
            Under30=true;
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 2단계 보호 모드로 전환되었습니다. 더욱 강력한 에너지가 방출됩니다. ";
            StartCoroutine(ExecuteAfterDelayText(3f));
        }
        if (BossHp <= 0f)
        {
            // 추가적인 처리 (보스 사망 등)
            BossDefeated();
        }
    }

    void BossDefeated()
    {
        die();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            if(clear){
                if(first){
                    light.color =  Color.red;
                    StartCoroutine(MonitorBulb());
                    first=false;
                }
                else{UpdateHealth(-1f);}
            }
            
        }
        
    }
    private IEnumerator MonitorBulb(){
        
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        rend1.material=Error1;
        rend2.material=Error2;
        rend3.material=Error1;
        yield return new WaitForSeconds(1f);
        rend1.material=Error2;
        rend2.material=Error1;
        rend3.material=Error2;
        yield return new WaitForSeconds(1f);
        rend1.material=Error1;
        rend2.material=Error2;
        rend3.material=Error1;
        yield return new WaitForSeconds(1f);
        rend1.material=Error2;
        rend2.material=Error1;
        rend3.material=Error2;
        yield return new WaitForSeconds(1f);
        rend1.material=Error1;
        rend2.material=Error2;
        rend3.material=Error1;
        yield return new WaitForSeconds(1f);
        rend1.material=Error2;
        rend2.material=Error1;
        rend3.material=Error2;
        yield return new WaitForSeconds(1f);
        light.enabled=false;
        rend1.material=Black;
        rend2.material=Black;
        rend3.material=Black;
        yield return new WaitForSeconds(3.0f);
        light.enabled=true;
        light.color =  Color.white;
        BossSlider.gameObject.SetActive(true);
        InitializeHealthBar();
        BossText.SetActive(true);
        touch=true;
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        BossAni.enabled=true;
    }

}
