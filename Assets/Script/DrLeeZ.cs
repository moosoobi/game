using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrLeeZ : MonoBehaviour
{
    public DrLee dr;
    public bool first=true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if(first){
                dr.StartConversation();
                first=false;
                

                
            }
            
        }
    }
}
