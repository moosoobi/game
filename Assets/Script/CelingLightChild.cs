using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelingLightChild : MonoBehaviour
{
    public CelingLight CelingLight;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            CelingLight.LightOff();
            
        }
    }
}
