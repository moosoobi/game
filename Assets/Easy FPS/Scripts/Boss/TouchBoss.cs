using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBoss : MonoBehaviour
{
    public Boss boss;
    public bool zzz=false;

    void Start()
    {
        boss=GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }
    void Update()
    {
        
        if(zzz&&Input.GetKeyDown(KeyCode.Z)){
            boss.touchboss();
            Destroy(gameObject);
        }
        
        
    
    }
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
}
