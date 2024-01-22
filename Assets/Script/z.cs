using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : MonoBehaviour
{
    public GunScript gun;
    
    
    
   
    private void OnTriggerEnter(Collider other)
    {
        
        gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
        if (other.CompareTag("Player"))
        {   
            gun.zcrosschange();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
        if (other.CompareTag("Player"))
        {   
            gun.zcrosschange();
        }
    }
   

    
    

}
