using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyCore : Quest
{

    public QuestState CurrentState;
    public string[] dialogue;
    public string[] dialogue1;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    private bool zzz=false;
    public GunInventory guninventory;
    public AudioSource SecuritySound;
    public AudioSource RadioSound;
    public AudioSource UrgentSound;
    static public float CoreHp=10f;
    public float CoreMaxHp=10f;
    public TextMeshProUGUI Core;
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
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
            EndDialogue();
        }
        
    }
    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=name;
        npcDialogueBox.text=dialogue[0];
    }

    private void OnTriggerEnter(Collider other)
    {    
            zzz=true;
            if (other.CompareTag("Attack")){
                
                if(!first){
                    Gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
                    Gun.Talking();
                    SecuritySound.Play();
                    healthSlider.gameObject.SetActive(true);
                    Core.gameObject.SetActive(true);
                    first=true;
                    healthSlider.maxValue = CoreMaxHp;
                    healthSlider.value = CoreHp;
                    StartConversation();
                    StartCoroutine(LightBlub());
                    for(int i=0;i<8;i++){
                        myDoor[i].Play(dooropen, 0, 0.0f);
                    }
                    
                    
                }
                UpdateHealth(-0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {    
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
        Gun.NotTalking();
        Leg2RobotBlue1.SetDestination(targetDestination1);
        Leg2RobotBlue2.SetDestination(targetDestination2);
        Leg2RobotRed1.SetDestination(targetDestination3);
        Leg2RobotRed2.SetDestination(targetDestination4);
        Leg4Robot1.SetDestination(targetDestination5);
        Leg4Robot2.SetDestination(targetDestination6);
        Leg4Robot3.SetDestination(targetDestination7);
        Leg4Robot4.SetDestination(targetDestination8);
    }
    public void UpdateHealth(float newHP)
    {

        CoreHp += newHP;

        // 슬라이더에 반영
        healthSlider.value = CoreHp;

        // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
        if (CoreHp <= 0f)
        {
            Debug.Log("파괴");
        }
    }
    public void Respawn(){
        for(int i=0;i<8;i++){
            myDoor[i].Play("DoorClose", 0, 0.0f);
        }
        CoreHp=10.0f;
        first=false;
        UpdateHealth(0);
    }
    private IEnumerator LightBlub(){
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = false;
            light[i].color =  Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].enabled = true;
            light[i].color =  Color.red;
        }
        
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<21;i++){
            light[i].color =  Color.white;
        }
    }

}
