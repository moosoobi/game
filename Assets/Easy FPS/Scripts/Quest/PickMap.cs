using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickMap : MonoBehaviour
{
    public GameObject map;
    public bool zzz=false;
    public bool ifpick=false;
    public bool show=true;
    public bool z;
    public TextMeshProUGUI Text;
    public GameObject text1;
    public TextMeshProUGUI Text2;
    public DialogueManager dia;
    public GunPick gunpick;
    private bool gunpickbool=false;
    public TextMeshProUGUI QuestText;
    private string Description="책상에서 지도를 얻어라.";

    void Update()
    {
        

        if(zzz&&dia.stage==1){
            if(Input.GetKeyDown(KeyCode.Z)){
                text1.SetActive(true);
                Text.text="X를 누르면 지도를 확인할 수 있습니다.";
                StartCoroutine(ExecuteAfterDelayText(3f));
                ifpick=true;
                if(!gunpickbool){
                    gunpickbool=true;
                    gunpick.QuestActive();
                }
            }
        }
        if(ifpick){
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
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
    public void QuestActive(){
        Text2.text="책상에서 지도를 얻어라.";
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        text1.SetActive(false);
    }
}
