using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : MonoBehaviour
{
    public bool zzz=false;
    public GameObject cross;
    public GameObject cross1;
    
    void Update()
    {
        if(cross&&cross1){
            if(zzz==true){
				cross.SetActive(false);
				cross1.SetActive(true);
			}else{
				cross1.SetActive(false);
				cross.SetActive(true);
				}
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("2");
        if (other.CompareTag("Object"))
        {
            Debug.Log("1");
            zzz = true;
            StartCoroutine(ExecuteAfterDelay(3.0f));
        }
        
    }
    
    
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        
    }
}
