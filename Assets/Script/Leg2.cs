using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg2 : MonoBehaviour
{
    public Leg2RobotBlue blue;
    public bool first=true;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if(first){
                first=true;
                blue.Ifhit=true;
            } 
        }
    }
}
