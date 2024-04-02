using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveText : MonoBehaviour
{

    public bool active=true;
    void Update()
    {
        if(active){
            Invoke("Deactivate", 3.0f);
            active=false;
        }
    }

    void Deactivate()
    {
        active=true;
        gameObject.SetActive(false);
    }
}
