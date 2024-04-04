using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.UI;

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
    public GameObject BossBulletSpawn;
    public GameObject BossBullet;
    public AudioSource electricsound;
    public AudioSource lazersound;
    public AudioSource warningsound;
    private bool alive=true;
    private bool touch=false;
    public VideoPlayer Loading;
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
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
    static public float BossHp=100f;
    public float BossMaxHp=100f;
    public Slider BossSlider;
    public GameObject BossText;
    public Light light;

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
        Renderer rend1 = Screen1.GetComponent<Renderer>();
        rend1.material = Blue;
        Renderer rend2 = Screen2.GetComponent<Renderer>();
        rend2.material = Yellow;
        Renderer rend3 = Screen3.GetComponent<Renderer>();
        rend3.material = Pink;
        StartConversation();
    }

    public void touchboss(){
        
        if(warningsound){warningsound.Play();}
        BlackScreen.SetActive(true);
        Monitor.SetActive(true);
        Loading.Play();
        player.GetComponent<MouseLookScript>().enabled = false;
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
            // 모든 패턴이 실행된 경우 초기화 또는 다른 동작 수행
            // 예: currentPatternIndex를 0으로 초기화
            currentPatternIndex = 0;
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
        

        int randomValue = GetRandomNumber(0, 3);
        Vector3 position=new Vector3(BossBulletSpawn.transform.position.x, BossBulletSpawn.transform.position.y, BossBulletSpawn.transform.position.z);
        Quaternion rotation = Quaternion.Euler(BossBulletSpawn.transform.rotation.eulerAngles.x, Random.Range(0, 360), BossBulletSpawn.transform.rotation.eulerAngles.z);
        GameObject obstacle = Instantiate(BossBullet,position , rotation);
        electricsound.Play();

        
        
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
            StartCoroutine(ExecuteAfterDelayText(3f));
            LazerAttack();
            yield return new WaitForSeconds(10.0f);
        }else if(currentPatternIndex==1){
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 강력한 에너지볼을 방출합니다.";
            StartCoroutine(ExecuteAfterDelayText(3f));
            Invoke("StopSpawningObstacles", 18f);
            InvokeRepeating("BulletAttack", 0f, 0.2f);

            yield return new WaitForSeconds(20f);
        }else if(currentPatternIndex==2){
            Text1.SetActive(true);
            text1.text="메인 컴퓨터가 전투로봇을 호출합니다.";
            StartCoroutine(ExecuteAfterDelayText(3f));
            yield return new WaitForSeconds(duration);
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

        // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
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
        Renderer rend1 = Screen1.GetComponent<Renderer>();
        Renderer rend2 = Screen2.GetComponent<Renderer>();
        Renderer rend3 = Screen3.GetComponent<Renderer>();
        
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
        BossText.SetActive(true);
        touch=true;
    }

}
