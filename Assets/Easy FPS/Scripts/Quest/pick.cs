using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
    public GunPick gunpick;
    public bool zzz=false;
    
    
    void Awake()
    {
        gunpick=GameObject.FindGameObjectWithTag("QuestManager").GetComponent<GunPick>();
    }
    void Update()
    {
        
        if(gunpick&&zzz){
            if(Input.GetKeyDown(KeyCode.Z)){
                Debug.Log(gunpick.currentState);
                if(gunpick.currentState==GunPick.QuestState.Active){
                    gunpick.pickup();
                    Destroy(gameObject);
                }
                
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
}
