using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : MonoBehaviour
{
    public GunScript gun;
    
   
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {   
            gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
            if(gun){gun.ZcrossOn();}
            
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {   
            gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
            if(gun){gun.ZcrossOff();}
        }
    }
   

    
    

}
