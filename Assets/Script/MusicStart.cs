using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource Music1;
    public bool Clear=false;
    public bool zzz=false;
    public bool first=true;



    void Update()
    {
        if(zzz){
            if(first){
                StopAllAudioSources();
                first=false;
                Music.Play();
                if(Music1){Music1.Play();}
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if(Clear){
                zzz=true;
            } 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            if(Clear){
                zzz=true;
            }
        }
    }

}
