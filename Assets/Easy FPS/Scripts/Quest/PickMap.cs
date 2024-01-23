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
    public GameObject text1;
    void Update()
    {
        
        zz=GetComponent<DrawerController>().closeTrigger;
        z=GetComponent<DrawerController>().zzzz;
        if(z){
            if(Input.GetKeyDown(KeyCode.Z)){
                Text.text="Bar로 이동해서 npc에게 말을 거시오.";
                text1.SetActive(true);
                StartCoroutine(ExecuteAfterDelay(3f));
            }
        }
        if(zz){
            zzz=true;
        }
        if(zzz){
            if(Input.GetKeyDown(KeyCode.X)){
                
                if(show){
                    map.SetActive(true);
                    
                }else if(!show){
                    map.SetActive(false);
                    
                }
                show=!show;
                
            }
        }
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        text1.SetActive(false);
    }
}
