using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public AudioSource RoomBackground;
    public AudioSource BarBackground;
    public First_Bar firsrbar;
    public bool PlayerIn=true;
    public bool first=true;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")&&PlayerIn&&first){
            RoomBackground.Stop();
            BarBackground.Play();
            firsrbar.Positivez();
            PlayerIn=false;
        }else if(other.CompareTag("Player")&&!PlayerIn){
            RoomBackground.Play();
            BarBackground.Stop();
            PlayerIn=true;
            
        }else if(other.CompareTag("Player")&&PlayerIn&&!first){
            RoomBackground.Stop();
            BarBackground.Play();
            PlayerIn=false;
        }

    }

}
