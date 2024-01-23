using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickMap : MonoBehaviour
{
    public GameObject map;
    public bool zz;
    public bool zzz;
    public bool show=true;
    public bool z;
    public TextMeshProUGUI Text;
    void Update()
    {
        
        zz=GetComponent<DrawerController>().closeTrigger;
        z=GetComponent<DrawerController>().zzzz;
        if(z){
            if(Input.GetKeyDown(KeyCode.Z)){
                Text.text="Bar로 이동해서 npc에게 말을 거시오.";
            }
        }
        if(zz){
            zzz=true;
        }
        if(zzz){
            if(Input.GetKeyDown(KeyCode.X)){
                
                if(show){
                    map.SetActive(true);
                    show=false;
                }else if(!show){
                    map.SetActive(false);
                    show=true;
                }
                
            }
        }
    }
}
