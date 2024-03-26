using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    [SerializeField] public Animator myDoor=null;

    public bool openTrigger=true;
    public bool closeTrigger=false;

    public AudioSource DrawerOpen;
    public AudioSource DrawerClose;
    public AudioSource UrgentSound;
    public AudioSource BarSound;

    public string dooropen;
    public string doorclose;
    
    public bool Clear=false;
    public bool zzzz=false;

    public GunInventory guninventory;

    

    
    void Update()
    {
        
        if(zzzz){
            if (Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
                if(openTrigger){
                    if(UrgentSound&&!Clear){StopAllAudioSources();UrgentSound.Play();}
                    myDoor.Play(dooropen, 0, 0.0f);
                    closeTrigger=true;
                    openTrigger=false;
                    if (DrawerOpen)
                    DrawerOpen.Play ();
                    StartCoroutine(ExecuteAfterDelay(1f));
                }
                else if(closeTrigger){
                    myDoor.Play(doorclose, 0, 0.0f);
                    closeTrigger=false;
                    openTrigger=true;
                    if (DrawerClose)
                    DrawerClose.Play ();
                    StartCoroutine(ExecuteAfterDelay(1f));
                }
            }

        }
    }
    void StopAllAudioSources()
    {
        // Scene에 있는 모든 AudioSource를 가져옵니다.
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // 모든 AudioSource를 반복하면서 정지시킵니다.
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        zzzz=true;
        StartCoroutine(ExecuteAfterDelay(0.5f));
        
    }
    
    
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        zzzz=false;
    }

}
