using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCircle : MonoBehaviour
{
    public EnergyCore core;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            player.GetComponent<PlayerMovementScript>().enabled = false;
            player.GetComponent<PlayerMovementScript>().currentSpeed=0;
            core.Circle=true;
            gameObject.SetActive(false);
        }
        
        
    }
}
