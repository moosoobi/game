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
    public VideoPlayer TimerVideo;
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject Timer1;
    public GameObject FixingCamera;
    public GameObject NoiseVideo1;
    public GameObject NoiseVideo2;
    public GameObject NoiseVideo3;
    public Material Blue;
    public Material Yellow;
    public Material Pink;
    public Material Error1;
    public Material Error2;
    public Material Black;
    public Material GlassM;
    public Material Under;
    public Material Trans;
    public Material Timer;
    public TextMeshProUGUI Text;
    public string Description;
    public TextMeshProUGUI QuestText;
    public AudioSource RadioSound;
    public string[] dialogue;
    public string[] dialogue1;
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
    public Renderer rend4;
    public Renderer rend5;
    public Renderer rend6;
    private Coroutine currentCoroutine;
    private Coroutine currentCoroutine1;
    public int Fixing=0;
    public bool Under50=false;
    public bool Under30=false;
    public bool Look=false;
    public bool FixingLotation=false;
    public int Stage=0;
    public PlayerHp PlayerHp;
    public Light SpotLight;
    public Light BossLight;
    public Light EndingMonitorLight;
    public GameObject Turn_Off;
    public GameObject Glass;
    public GameObject BossUnder;
    public GameObject EndingVolumn;
    public bool IfDie=false;
    public EndingMonitor Ending;
    public AudioSource ErrorSound;
    public AudioSource BossBg;
    public GameObject Guide;
    public GameObject ShootGuide;
    public GameObject BossWord1;
    public GameObject BossWord2;
    public AudioSource QuestSound;
    private void Start()
    {
        
        rend1 = Screen1.GetComponent<Renderer>();//left
        rend2 = Screen2.GetComponent<Renderer>();//right
        rend3 = Screen3.GetComponent<Renderer>();//main   
        rend4 = Glass.GetComponent<Renderer>();
        rend5 = BossUnder.GetComponent<Renderer>();
        rend6 = Timer1.GetComponent<Renderer>();
     
    }


    void Update()
    {
        if(IfDie){
            StartCoroutine(die());
            IfDie=false;
        }
        if(Look){
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0f; // Y축 방향은 무시 (수평 방향으로만 회전)
            // 방향 벡터를 바탕으로 회전 값 생성
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            Vector3 euler = targetRotation.eulerAngles;
            euler.x = -90f; // x 값을 -90도로 설정
            if(FixingLotation){}
            else{euler.z += -40f;}
            
            targetRotation = Quaternion.Euler(euler);
            transform.rotation = targetRotation;
        }
        if(touch){
            if(alive){
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
        if(Stage==0){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
        }else if(Stage==1){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue1.Length){
                EndDialogue();
            }
        }
        
        
        
    }

    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
    }
    public void QuestActive1(){
        Text.text="의문의 빛을 조사하십시오.";
        StartCoroutine(ChangeColor());
        Guide.SetActive(false);
    }
    private IEnumerator ChangeColor(){
        QuestSound.Play();
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator Loading1()
    {
        yield return new WaitForSeconds(14f);
        BlackScreen.SetActive(false);
        Monitor.SetActive(false);
        rend1.material = Blue;
        rend2.material = Yellow;
        rend3.material = Pink;
        StartConversation();
    }

    public void touchboss(){
        BossWord1.SetActive(true);
        BossWord2.SetActive(true);
        Turn_Off.SetActive(true);
        BlackScreen.SetActive(true);
        Monitor.SetActive(true);
        Loading.Play();
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().currentSpeed = 0;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        Look=true;
        StopAllAudioSources();
        StartCoroutine(ErrorEffect());
        StartCoroutine(Loading1());

    }
    public void StopAllAudioSources()
    {
        // Scene에 있는 모든 AudioSource를 가져옵니다.
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // 모든 AudioSource를 반복하면서 정지시킵니다.
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }
    }
    public void LightOn(){
        SpotLight.enabled=true;
        BossLight.enabled=true;
        EndingMonitorLight.enabled=false;
        EndingVolumn.SetActive(false);
        Turn_Off.SetActive(true);
        rend4.material=GlassM;
        rend5.material=Under;
    }
    
    public IEnumerator die(){
        
        BossBg.Stop();
        BossSlider.gameObject.SetActive(false);
        Lazer.SetActive(false);
        CancelInvoke("BulletAttack");
        StopCoroutine(currentCoroutine);
        isAttacking=true;
        Look=false;
        alive=false;
        rend1.material=Black;
        
        rend2.material=Black;
        rend3.material=Black;
        rend4.material=Black;
        rend5.material=Black;
        NoiseVideo1.SetActive(true);
        NoiseVideo2.SetActive(true);
        NoiseVideo3.SetActive(true);
        BossWord1.SetActive(false);
        BossWord2.SetActive(false);
        BossAni.enabled=true;
        BossAni.Play("death", 0, 0.0f);
        SpotLight.enabled=false;
        BossLight.enabled=false;
        EndingMonitorLight.enabled=true;
        EndingVolumn.SetActive(true);
        Turn_Off.SetActive(false);
        Ending.Clear=true;
        yield return new WaitForSeconds(3.0f);
        Stage=1;
        player.GetComponent<GunInventory>().ChangeWeapon1();
        StartConversation();
    }
    public void StartConversation(){
        RadioSound.Play();
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=" ";
        if(Stage==0){npcDialogueBox.text=dialogue[0];}
        if(Stage==1){npcDialogueBox.text=dialogue1[0];}
        zzz=false;
        


    }


    public void ContinueConversation(){
            curResponseTracker++;
            if(Stage==0){
                if(curResponseTracker>dialogue.Length){
                    curResponseTracker=dialogue.Length;
                }
                else if(curResponseTracker<dialogue.Length)
                {
                    npcDialogueBox.text=dialogue[curResponseTracker];
                }
            }else if(Stage==1){
                if(curResponseTracker>dialogue1.Length){
                    curResponseTracker=dialogue1.Length;
                }
                else if(curResponseTracker<dialogue1.Length)
                {
                    npcDialogueBox.text=dialogue1[curResponseTracker];
                }
            }
            
    }

    public void EndDialogue(){
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        if(Stage==0){
            QuestActive();
            player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
            ShootGuide.SetActive(true);
            clear=true;
            PlayerHp.stage=2;
        }else if(Stage==1){
            QuestActive1();

        }
        
    }
    IEnumerator ExecuteAttackPattern()
    {
        isAttacking = true;

        
        if (currentPatternIndex < AttackLength)
        {
            // 공격 패턴 실행
            yield return currentCoroutine1=StartCoroutine(Execute(currentPatternIndex));
            // 다음 패턴으로 이동
            currentPatternIndex++;
        }
        else
        {
            if(!Under30){
                int randomValue = GetRandomNumber(3, 6);
                yield return currentCoroutine1=StartCoroutine(Execute(randomValue));
            }else{
                int randomValue = GetRandomNumber(7, 10);
                yield return currentCoroutine1=StartCoroutine(Execute(randomValue));
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
    
    public IEnumerator ErrorEffect(){
        
        yield return new WaitForSeconds(5.5f);
        ErrorSound.Play();
        yield return new WaitForSeconds(1.0f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
        ErrorSound.Play();
        yield return new WaitForSeconds(0.1f);
    }
    public IEnumerator Execute(int currentPatternIndex)
    {   
        
        if(currentPatternIndex==0){
            Text1.SetActive(true);
            rend1.material=Trans;
            NoiseVideo1.SetActive(true);
            text1.text=" 메인 컴퓨터가 바닥을 훑는 레이저를 발사합니다.";
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ExecuteAfterDelayText(3f));
            LazerAttack();
            yield return new WaitForSeconds(10.0f);
            NoiseVideo1.SetActive(false);
            rend1.material=Blue;
            
        }else if(currentPatternIndex==1){
            Text1.SetActive(true);
            rend2.material=Trans;
            NoiseVideo2.SetActive(true);
            text1.text="메인 컴퓨터가 강력한 에너지볼을 방출합니다.";
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ExecuteAfterDelayText(3f));
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 1f);
            
            yield return new WaitForSeconds(18f);
            NoiseVideo2.SetActive(false);
            rend2.material=Yellow;
        }else if(currentPatternIndex==2){
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 전투로봇을 호출합니다.";
            rend3.material=Trans;
            NoiseVideo3.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ExecuteAfterDelayText(3f));
            FightRobot();
            yield return new WaitForSeconds(10.0f);
            NoiseVideo3.SetActive(false);
            rend3.material=Pink;
        }else if(currentPatternIndex==3){
            rend1.material=Trans;
            NoiseVideo1.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            LazerAttack();
            yield return new WaitForSeconds(10.0f);
            NoiseVideo1.SetActive(false);
            rend1.material=Blue;
        }else if(currentPatternIndex==4){
            rend2.material=Trans;
            NoiseVideo2.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 3f);
            yield return new WaitForSeconds(18f);
            NoiseVideo2.SetActive(false);
            rend2.material=Yellow;
        }else if(currentPatternIndex==5){
            rend3.material=Trans;
            NoiseVideo3.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            FightRobot();
            yield return new WaitForSeconds(10.0f);
            NoiseVideo3.SetActive(false);
            rend3.material=Pink;
        }
        else if(currentPatternIndex==6){
            
            Lazer.SetActive(false);
            CancelInvoke("BulletAttack");
            StopCoroutine(currentCoroutine);
            isAttacking=false;
            Fixing=0;
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 수리 로봇을 호출합니다. 30초 이내에 수리로봇을 파괴하여 수리를 중단해야 합니다.";
            FixingLotation=true;
            StartCoroutine(ExecuteAfterDelayText(3f));
            yield return new WaitForSeconds(3.0f);
            TimerVideo.Play();
            rend6.material=Timer;
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
            yield return new WaitForSeconds(30.0f);
            rend6.material=Black;
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
            FixingLotation=false;
            BossAni.Play("idle", 0, 0.0f);
            FixingCamera.SetActive(false);
            clear=true;
            if(Fixing==10){
                Under50=true;
                Text1.SetActive(true);
                text1.text="메인 컴퓨터가 수리에 실패했습니다. 과부하로 인해 10초간 동작이 중지됩니다.";
                StartCoroutine(ExecuteAfterDelayText(10f));
                yield return new WaitForSeconds(10.0f);
                touch=true;
                isAttacking=false;
                
            }else{
                Text1.SetActive(true);
                text1.text="메인 컴퓨터가 수리에 성공했습니다. 많은 양의 에너지가 공급 됩니다.";
                StartCoroutine(ExecuteAfterDelayText(3f));
                touch=true;
                BossHp=70;
                UpdateHealth(0);
                isAttacking=false;
            }
        }else if(currentPatternIndex==7){
            rend1.material=Blue;
            NoiseVideo1.SetActive(true);
            
            yield return new WaitForSeconds(3.0f);
            LazerAttack();
            Lazer.GetComponent<BossLazer>().rotationSpeed=80;
            yield return new WaitForSeconds(10.0f);
            NoiseVideo1.SetActive(false);
            rend1.material=Blue;
        }else if(currentPatternIndex==8){
            rend2.material=Yellow;
            NoiseVideo2.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 1f);
            
            yield return new WaitForSeconds(18f);
            NoiseVideo2.SetActive(false);
            rend2.material=Yellow;
        }else if(currentPatternIndex==9){
            rend3.material=Pink;
            NoiseVideo3.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            FightRobot2();
            yield return new WaitForSeconds(10.0f);
            NoiseVideo3.SetActive(false);
            rend3.material=Pink;
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
        BossHp=100f;
        BossSlider.maxValue = BossMaxHp;

        // 현재 HP 설정
        BossSlider.value = BossHp;
    }
    public void UpdateHealth(float newHP)
    {
        if(clear){
                // 현재 HP 갱신
            BossHp += newHP;

            // 슬라이더에 반영
            BossSlider.value = BossHp;
            if(!Under50){
                if (BossHp <= 50f)
                {
                    touch=false;
                    
                    StartCoroutine(Execute(6));
                    clear=false;
                    Lazer.SetActive(false);
                    CancelInvoke("BulletAttack");
                    StopCoroutine(currentCoroutine);
                    isAttacking=false;
                    
                    
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
                StartCoroutine(die());
                StopCoroutine(currentCoroutine);
            }
        }
        
    }

    public void ReStart(){
        first=true;
        BossAni.enabled=false;
        Under30=false;
        Under50=false;
        touch=false;
        BossSlider.gameObject.SetActive(false);
        Look=false;
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, +45));
        Lazer.SetActive(false);
        CancelInvoke("BulletAttack");
        StopCoroutine(currentCoroutine);
        isAttacking=false;
        rend1.material=Blue;
        rend2.material=Yellow;
        rend3.material=Pink;
        rend1.material=Black;
        currentPatternIndex=0;
        
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
        ShootGuide.SetActive(false);
        warningsound.Play();
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
        Text1.SetActive(true);
        text1.text=" 메인 컴퓨터가 바닥을 훑는 레이저를 발사합니다.";
        yield return new WaitForSeconds(1f);
        rend1.material=Error2;
        rend2.material=Error1;
        rend3.material=Error2;
        

        
        yield return new WaitForSeconds(1f);
        light.enabled=false;
        rend1.material=Blue;
        rend2.material=Yellow;
        rend3.material=Pink;
        warningsound.Stop();
        
        light.enabled=true;
        light.color =  Color.white;
        BossSlider.gameObject.SetActive(true);
        InitializeHealthBar();
        Look=true;
        touch=true;
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        BossAni.enabled=true;
        BossBg.Play();
    }

}
