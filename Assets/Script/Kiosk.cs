using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiosk : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI UiText;
    public bool zzzz=false;

    public ob

    private void OnTriggerEnter(Collider other)
    {
        
        zzzz=true;
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        zzzz=false;
       
        
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiText.color=Color.white;
        UiObject.SetActive(false);
        
    }
}
