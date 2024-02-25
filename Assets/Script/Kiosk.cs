using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kiosk : MonoBehaviour
{
    public TextMeshProUGUI UiText;
    public bool zzzz=false;
    public GameObject UiObject;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public GunInventory guninventory;
    public GameObject Cursor;
    public GameObject KioskUi;
    public GameObject player;
    public Cart cart;
    public int stack=1;



    void Update()
    {
         if(zzzz){
            if(Input.GetMouseButtonDown(0)&&guninventory.currneguniscard()&&cart.IsTalking()&&stack==0){
                stack=1;
            }
            else if(Input.GetMouseButtonDown(0)&&guninventory.currneguniscard()&&cart.IsTalking()&&stack==1){
                Cursor.SetActive(true);
                KioskUi.SetActive(true);
                player.GetComponent<MouseLookScript>().enabled = false;
                player.GetComponent<PlayerMovementScript>().enabled = false;
                stack=0;
            }else if(Input.GetMouseButtonDown(0)&&!guninventory.currneguniscard()&&!isTalking){
                dialogueUI.SetActive(true);
                npcName.text="";
                npcDialogueBox.text="카드가 필요할 것 같다.";
                isTalking=true;
            }else if(Input.GetMouseButtonDown(0)&&!guninventory.currneguniscard()&&isTalking){
                isTalking=false;
                dialogueUI.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        zzzz=true;
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        zzzz=false;
       
        
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiText.color=Color.white;
        UiObject.SetActive(false);
        
    }
}
