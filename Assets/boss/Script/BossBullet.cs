using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float maxSpeed = 15.0f;

	void Start()
    {
        
        MoveBullet();
        Invoke("DeactivateAfterDelay", 3f);
    }

    void DeactivateAfterDelay()
    {
        Destroy(gameObject);
    }
    // 총알이 움직이는 방향으로 이동하는 함수
    private void MoveBullet()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * maxSpeed;
    }
}
