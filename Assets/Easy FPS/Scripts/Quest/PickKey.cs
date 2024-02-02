using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickKey : MonoBehaviour
{
    public GunInventory guninventory;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public bool zzz=false;
    
    void Update()
    {
        if(zzz&&Input.GetKeyDown(KeyCode.Z)){
            guninventory.PositiveKey();
            UiObject.SetActive(true);
            UiText.text="3번을 눌러 키를 꺼내십시오.";
            StartCoroutine(ExecuteAfterDelayText(0.5f)); 
        }
    }
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
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
