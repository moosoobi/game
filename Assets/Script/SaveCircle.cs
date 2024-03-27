using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCircle : MonoBehaviour
{

    public GameObject Save;
    


 
    


    void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player")){
                Save.SetActive(true);
                gameObject.SetActive(false);
            }
        
        
    }
}
