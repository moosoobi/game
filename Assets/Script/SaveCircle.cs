using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveCircle : MonoBehaviour
{

    public GameObject Save;
    public GameObject Guide;
    public PlayerHp playerhp;
    public int stage;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public Animator DoorAni;
    public RealBoss Boss;
    public AudioSource UrgentSound;
    
    


 
    


    void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player")){
                if(stage==0){
                    StopAllAudioSources();
                    UrgentSound.Play();
                    if(DoorAni){DoorAni.Play("Door2Open", 0, 0.0f);}
                    Save.SetActive(true);
                    gameObject.SetActive(false);
                }
            
                if(stage==1){
                    UiObject.SetActive(true);
                    UiText.text="Hp회복!";
                    StartCoroutine(ExecuteAfterDelayText(3f)); 
                    playerhp.stage=stage;
                    playerhp.PlayerCurHp=1000f;
                    playerhp.UpdateHealth(0);
                    Save.SetActive(true);
                    
                    if(Boss){
                        UiObject.SetActive(false);
                        Boss.touchboss();
                    }
                }else{
                    Save.SetActive(true);
                    gameObject.SetActive(false);
                    
                }
                
                
                
                
                
            }
        
        
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
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
