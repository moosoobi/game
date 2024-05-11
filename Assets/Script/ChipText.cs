using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChipText : MonoBehaviour
{

    
    public void Active()
    {
        Invoke("Deactivate", 3.0f);
    }

    void Deactivate()
    {
        // 타겟 오브젝트를 비활성화합니다.
        gameObject.GetComponent<TextMeshProUGUI>().text="";
    }

}
