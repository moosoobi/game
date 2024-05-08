using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact1 : MonoBehaviour
{
    public GunInventory guninventory;
    public bool zzz=false;
    public GameObject text1;//uitext
    public TextMeshProUGUI Text;//uitext

    void Start()
    {
        guninventory=GameObject.FindGameObjectWithTag("Player").GetComponent<GunInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(zzz&&Input.GetMouseButtonDown(0)&&!guninventory.IfHand()){
                text1.SetActive(true);
                Text.text="숫자키 1번을 눌러 대화할 수 있습니다.";
                StartCoroutine(ExecuteAfterDelayText(1.5f));
            }
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        text1.SetActive(false);
    }
    private void OnTriggerEnter(Collider other){
        
        zzz=true;
    }
    private void OnTriggerExit(Collider other){

        zzz=false;
    }
}
