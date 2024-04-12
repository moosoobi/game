using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCircle : MonoBehaviour
{
    public EnergyCore core;
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            
            Active=false;
            gameObject.SetActive(false);
        }
        
        
    }
}
