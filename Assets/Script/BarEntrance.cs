using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarEntrance : MonoBehaviour
{
    private bool first=true;
    public SlidingDoor door;
    private void OnTriggerEnter(Collider other){
        
            if (other.CompareTag("Player")&&first){
                door.active=false;
                first=false;
            }
    }
}
