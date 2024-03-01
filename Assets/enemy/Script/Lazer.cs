using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    
    public GameObject prefabToClone;

    public bool IfHit=false;

    public float raycastDistance = 0.2f;


    void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up*-1.0f, out hit, raycastDistance))
        {
            // 앞에 물체가 있으면 아무 작업을 하지 않음
            Debug.Log("물체가 있습니다: " + hit.collider.gameObject.name);
        }
        else
        {
            GameObject clone = Instantiate(prefabToClone, transform.position+transform.up*-0.2f, transform.rotation);
        }
        
    }



}
