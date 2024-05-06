using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideCircle : MonoBehaviour
{
    public GameObject Guide;
    public RealBoss Boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            if(Boss){Boss.touchboss();}
            if(Guide){Guide.SetActive(false);}
            gameObject.SetActive(false);
            
        }
    }
}
