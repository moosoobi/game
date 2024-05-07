using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public AudioSource RoomBackground;
    public AudioSource BarBackground;
    public SlidingDoor door;
    public First_Bar firsrbar;
    public bool PlayerIn=true;
    public bool first=true;

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

    private void OnTriggerEnter(Collider other){
        if(door.active){
            if (other.CompareTag("Player")&&PlayerIn&&first){
            StopAllAudioSources();
            BarBackground.Play();
            door.active=false;
            firsrbar.Positivez();
            PlayerIn=false;
            }else if(other.CompareTag("Player")&&!PlayerIn){
                StopAllAudioSources();
                
                PlayerIn=true;
                
            }else if(other.CompareTag("Player")&&PlayerIn&&!first){
                StopAllAudioSources();
                BarBackground.Play();
                PlayerIn=false;
            }
        }
        

    }

}
