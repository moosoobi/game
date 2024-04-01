using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairDown : MonoBehaviour
{

    public AudioSource stairSound; // 계단 내려갈 때 재생할 소리
    
    private bool isDescendingStair = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 계단에 닿았을 때
        {
            isDescendingStair = true;
            stairSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 계단에서 벗어났을 때
        {
            isDescendingStair = false;
            stairSound.Stop();
        }
    }
}
