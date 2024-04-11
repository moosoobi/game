using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveCircle : MonoBehaviour
{

    public GameObject Save;
    public PlayerHp playerhp;
    public int stage;
    public MusicStart MUSIC;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public Animator DoorAni;
    
    


 
    


    void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player")){
                if(stage==0){if(DoorAni){DoorAni.Play("Door2Open", 0, 0.0f);}}
                if(MUSIC){MUSIC.Clear=true;}
                if(stage==1){
                    UiObject.SetActive(true);
                    UiText.text="Hp회복!";
                    StartCoroutine(ExecuteAfterDelayText(3f)); 
                    playerhp.stage=stage;
                    playerhp.PlayerCurHp=300f;
                    playerhp.UpdateHealth(0);
                    Save.SetActive(true);
                }else{
                    Save.SetActive(true);
                    gameObject.SetActive(false);
                }
                
                
                
                
                
            }
        
        
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
