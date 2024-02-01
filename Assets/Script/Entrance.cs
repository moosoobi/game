using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public AudioSource RoomBackground;
    public AudioSource BarBackground;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            RoomBackground.Stop();
            BarBackground.Play();
        }
    }

}
