using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : MonoBehaviour
{
    public GameObject zz;
    
    private void OnTriggerEnter(Collider other){
        zz.SetActive(true);
       
    }
    private void OnTriggerExit(Collider other){
        zz.SetActive(false);
    
    }
}
