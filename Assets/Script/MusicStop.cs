using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStop : MonoBehaviour
{
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
            StopAllAudioSources();
        }
    }
}
