using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter5 : MonoBehaviour
{


    void Start()
    {
        // 5초 후에 DeactivateAfterDelay 함수 호출
        Invoke("DeactivateAfterDelay", 8f);
    }

    void DeactivateAfterDelay()
    {
        Destroy(gameObject);
    }


}
