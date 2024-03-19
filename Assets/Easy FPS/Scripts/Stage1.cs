using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage1 : MonoBehaviour
{
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public bool first=true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&first){
            first=false;
            UiObject.SetActive(true);
            UiText.text="Shift 키를 누르면 빠르게 이동할 수 있습니다.";
            StartCoroutine(ExecuteAfterDelayText(3f)); 

        }

        
        
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        
    }
}
