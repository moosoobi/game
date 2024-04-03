using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBoss : MonoBehaviour
{
    public RealBoss boss;
    public bool zzz=false;
    public GunInventory guninventory;
    public bool first=true;

 
    void Update()
    {
        
        if(zzz&&Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&first){
            boss.touchboss();
            first=false;
        }
        
        
    
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            zzz=true;
        }
        
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            zzz=false;
        }
    }
}
