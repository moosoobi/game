
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pick : MonoBehaviour
{
    public GunPick gunpick;
    public bool zzz=false;
    public DrawerController2 drawer;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public int stack=0;
    public bool Clear=false;
    public GunInventory guninventory;
    
    void Awake()
    {
        drawer=GameObject.FindGameObjectWithTag("PickMap").GetComponent<DrawerController2>();
    }
    void Update()
    {
        if(gunpick&&zzz&&Clear){
            if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()){
                if(stack==0){stack++;}
                if(gunpick.CurrentState==GunPick.QuestState.Active&&stack==1){
                    gunpick.pickup();
                    UiObject.SetActive(true);
                    UiText.text="숫자키 2번을 눌러 총을 들 수 있습니다.";
                    guninventory.GunBool=true;
                    StartCoroutine(ExecuteAfterDelayText(0.5f));   
                }
                
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        if(Clear){
            zzz=true;
        }
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
        private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        Destroy(gameObject);
    }
}
