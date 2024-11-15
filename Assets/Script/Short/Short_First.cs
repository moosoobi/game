using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Short_First : MonoBehaviour
{
    public AudioSource BarBg;
    public string[] dialogue;
    public int curResponseTracker=0;
    public bool isTalking=false;
    private bool zzz=false;
    public bool first=true;
    public bool Look=false;
    public GameObject player;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public TextMeshProUGUI Text;
    public string Description;
    public TextMeshProUGUI QuestText;
    public AudioSource RadioSound;
    public GameObject Key_Detail;
    public AudioSource QuestSound;
    public AudioSource DialogueSound;
    void Start()
    {
        Invoke("QuestActive", 3.0f);
        player.transform.rotation=Quaternion.Euler(new Vector3(0f, -90f, 0f));
        player.GetComponent<PlayerMovementScript>().enabled = false;
        player.GetComponent<MouseLookScript>().isrotation=false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
                
            ContinueConversation();          
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length&&isTalking==true){
            EndDialogue();
        }
        if(Look){
            player.transform.rotation=Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
    }
    
    public void QuestActive(){
        RadioSound.Play();
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text=" ";
        npcDialogueBox.text=dialogue[0];
        zzz=false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
    }
    public void StartConversation(){
        RadioSound.Play();
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="J";
        npcDialogueBox.text=dialogue[0];
        zzz=false;
        player.GetComponent<PlayerMovementScript>().enabled = false;


    }

    public void ContinueConversation(){
            DialogueSound.Play();
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
        player.GetComponent<PlayerMovementScript>().enabled = true;
        Text.text=Description;
        StartCoroutine(ChangeColor());
        player.GetComponent<MouseLookScript>().isrotation=true;
        player.GetComponent<MouseLookScript>().wantedYRotation=-90f;
        player.GetComponent<MouseLookScript>().wantedCameraXRotation=0f;
        player.GetComponent<GunInventory>().ChangeWeapon1();
        Key_Detail.SetActive(true);
        player.GetComponent<PlayerMovementScript>().IfCross=true;
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

    
}
