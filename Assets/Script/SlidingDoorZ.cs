using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorZ : MonoBehaviour
{
    public SlidingDoor door;
    private bool first=true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&first){
            first=false;
            door.active=false;
        }
    }
}
