using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideCircle : MonoBehaviour
{
    public GameObject Guide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            
            if(Guide){Guide.SetActive(false);}
            gameObject.SetActive(false);
            
        }
    }
}
