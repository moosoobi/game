using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyCore: Quest
{
    public GameObject Guide;
    public Vector3 targetPosition = new Vector3(8f, 413.8f, 432f);
    public GameObject Ring;
    public GameObject Save;
    public QuestState CurrentState;
    public EnergyCoreDoor Door;
    public string[] dialogue;
    public string[] dialogue1;
    public int stage=0;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public GameObject player;
    public bool isTalking=false;
    private bool zzz=false;
    public bool Open=false;
    public GunInventory guninventory;
    public AudioSource SecuritySound;
    public AudioSource RadioSound;
    public AudioSource UrgentSound;
    static public float CoreHp=30f;
    public float CoreMaxHp=30f;
    public TextMeshProUGUI Core;
    public TextMeshProUGUI QuestText;
    public TextMeshProUGUI Text2;//questtext
    public Slider healthSlider;
    public bool first=false;
    public GunScript Gun;
    public Light[] light;
    public Animator[] myDoor=null;
    public string dooropen;
    public Leg2RobotBlue Leg2RobotBlue1;
    public Leg2RobotBlue Leg2RobotBlue2;
    public Leg2RobotRed Leg2RobotRed1;
    public Leg2RobotRed Leg2RobotRed2;
    public Leg4Robot Leg4Robot1;
    public Leg4Robot Leg4Robot2;
    public Leg4Robot Leg4Robot3;
    public Leg4Robot Leg4Robot4;
    public Transform targetDestination1; 
    public Transform targetDestination2; 
    public Transform targetDestination3; 
    public Transform targetDestination4; 
    public Transform targetDestination5; 
    public Transform targetDestination6; 
    public Transform targetDestination7;
    public Transform targetDestination8;  
    public DrawerController Entrance;
    public GameObject Off1;
    public GameObject Off2;
    public GameObject Off3;


    public float dialogueInterval = 3f; // 대화 간격 (3초)




     public EnergyCore(QuestState currentState)
    {
        CurrentState=currentState;
    }

    void Start()
    {
        /*
        SecuritySound.Play();
        StartCoroutine(LightBlub());
        for(int i=0;i<8;i++){
            myDoor[i].Play(dooropen, 0, 0.0f);
        }
        */
    }
    void Update()
    {
        
        

        if(Input.GetMouseButtonDown(0)&&isTalking==true){
            ContinueConversation();
               
        }
        if(stage==0){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                
            }
        }else if(stage==1){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue1.Length){
                EndDialogue();
            }
        }
        
        
    }
    IEnumerator StartConversation()
    {
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text=dialogue[0];
        Leg2RobotBlue1.SetDestination(targetDestination1);
        Leg2RobotBlue2.SetDestination(targetDestination2);
        Leg2RobotRed1.SetDestination(targetDestination3);
        Leg2RobotRed2.SetDestination(targetDestination4);
        Leg4Robot1.SetDestination(targetDestination5);
        Leg4Robot2.SetDestination(targetDestination6);
        Leg4Robot3.SetDestination(targetDestination7);
        Leg4Robot4.SetDestination(targetDestination8);
        StartCoroutine(DoorClose());
        while (curResponseTracker< dialogue.Length)
        {
            // 대화 내용을 UI에 표시
            npcDialogueBox.text= dialogue[curResponseTracker];

            // 대화 간격만큼 기다린 후 다음 대화로 넘어감
            yield return new WaitForSeconds(dialogueInterval);

            // 다음 대화로 인덱스 증가
            curResponseTracker++;
        }

        EndDialogue();
    }

    IEnumerator StartConversation1(){
        yield return new WaitForSeconds(3.0f);
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text=dialogue1[0];
    }

    private void OnTriggerEnter(Collider other)
    {    
        zzz=true;
        if(Open){
            if (other.CompareTag("Attack")){
                
                if(!first){
                    
                    
                    SecuritySound.Play();
                    healthSlider.gameObject.SetActive(true);
                    
                    first=true;
                    healthSlider.maxValue = CoreMaxHp;
                    healthSlider.value = CoreHp;
                    StartCoroutine(StartConversation());
                    StartCoroutine(LightBlub());
                    for(int i=0;i<8;i++){
                        myDoor[i].Play(dooropen, 0, 0.0f);
                    }
                    
                    
                    
                    
                }
                if(CoreHp>0){UpdateHealth(-1f);}
                
            }
        }
            
    }
    public void QuestActive(){
        Text2.text="공격하는 적들을 피해 에너지 증폭장치를 부숴라.";
        StartCoroutine(ChangeColor());
    }
    public void QuestActive1(){
        Text2.text="지도에 표시된 곳으로 가라.";
        StartCoroutine(ChangeColor());
        Ring.transform.position=targetPosition;
        Save.SetActive(true);
        Guide.SetActive(true);
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator DoorClose(){
        yield return new WaitForSeconds(3f);
        for(int i=0;i<9;i++){
            myDoor[i].Play("DoorClose", 0, 0.0f);
        }
    }
    private void OnTriggerExit(Collider other)
    {    
            zzz=false;
    }
    public void ContinueConversation(){
        if(stage==0){
            
        }else if(stage==1){
            curResponseTracker++;
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
        if(stage==0){
            QuestActive();
            curResponseTracker=0;
            isTalking=false;
            dialogueUI.SetActive(false);
            
            
        }else if(stage==1){
            curResponseTracker=0;
            isTalking=false;
            dialogueUI.SetActive(false);
            QuestActive1();

            
        }
   
    }
    public void UpdateHealth(float newHP)
    {

        CoreHp += newHP;

        // 슬라이더에 반영
        healthSlider.value = CoreHp;

        // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
        if (CoreHp <= 0f)
        {
            Off1.SetActive(false);
            Off2.SetActive(false);
            Off3.SetActive(false);
            Leg2RobotBlue1.Hp=0;
            Leg2RobotBlue2.Hp=0;
            Leg2RobotRed1.Hp=0;
            Leg2RobotRed2.Hp=0;
            Leg4Robot1.Hp=0;
            Leg4Robot2.Hp=0;
            Leg4Robot3.Hp=0;
            Leg4Robot4.Hp=0;
            healthSlider.gameObject.SetActive(false);
            UrgentSound.Stop();
            RadioSound.Play();
            stage=1;
            Entrance.Clear=true;
            player.GetComponent<GunInventory>().ChangeWeapon1();

            StartCoroutine(StartConversation1());

        }
    }
    public void Respawn(){
        for(int i=0;i<10;i++){
            myDoor[i].Play("DoorClose", 0, 0.0f);
            Door.openTrigger=true;
        }
        Open=false;
        CoreHp=30.0f;
        first=false;
        UpdateHealth(0);
    }
    private IEnumerator LightBlub(){
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<2;i++){
            light[i].color =  Color.white;
        }
    }

}
