using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EleDoor : MonoBehaviour
{
    public Animator myDoor=null;

    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;

    public TextMeshProUGUI UiText;
    public GameObject UiObject;

    public string dooropen;
    public string doorclose;
    
    public bool openTrigger=true;
    public bool closeTrigger=false;
    public bool Lab=false;
    public bool zzzz=false;
    public bool first=true;
    
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI QuestText;
    public AudioSource RadioSound;
    public AudioSource LabBg;
    public GameObject Click;
    
    public BossEle bossele;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            zzzz=true;
            if(openTrigger&&!Lab){
                    myDoor.Play(dooropen, 0, 0.0f);
                    closeTrigger=true;
                    openTrigger=false;
                    if (DrawerOpen)
                    DrawerOpen.Play ();
                    UiObject.SetActive(true);
                    UiText.text="키패드를 이용해 층수를 입력하시오.";
                    StartCoroutine(ExecuteAfterDelayText(3f));
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            zzzz=false;
            if(closeTrigger&&first){
                myDoor.Play(doorclose, 0, 0.0f);
                closeTrigger=false;
                openTrigger=true;
                if (DrawerClose)
                DrawerClose.Play ();
                if(Lab){
                    first=false;
                    LabBg.Play();
                    StartCoroutine(StartConversation());
                }
            }
        }
    }

    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        
    }
    public void QuestActive(){
        Text.text="보스룸으로 올라가서 해킹칩을 심어라.";
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
    IEnumerator StartConversation()
    {
        Click.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        RadioSound.Play();
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text="역시 평범한 사무실은 아니었네.";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="안드로이드들이 순수한 인간을 납치해간다는 소문이 사실이었어. 이곳은 납치된 자들을 인체실험한 연구소인 것 같고.";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="아는 얼굴들이 보이는 것 같아.. 정말 끔찍하군";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="… …";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="위층에 메인 컴퓨터가 있어. 그것만 없앤다면… 정말 끝이겠지.";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="마지막 작전 수행을 부탁하네.";
        yield return new WaitForSeconds(3.0f);
        Click.SetActive(false);
        dialogueUI.SetActive(false);
        QuestActive();
        bossele.Clear=true;


        
    }
}
