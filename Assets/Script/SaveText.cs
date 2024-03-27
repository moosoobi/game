using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveText : MonoBehaviour
{

    
   void Start()
    {
        Invoke("Deactivate", 3.0f);
    }

    void Deactivate()
    {
        // 타겟 오브젝트를 비활성화합니다.
        gameObject.SetActive(false);
    }
}
