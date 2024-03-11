using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    
    public bool z=false;

    public bool Retrunz(){return z;}
    private void OnTriggerEnter(Collider other){
        
        z=true;
    }
    private void OnTriggerExit(Collider other){

        z=false;
    }
}
