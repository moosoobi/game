using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // 총알 속도

    // Start is called before the first frame update
    void Start()
    {
        // 총알에 속도를 추가하여 발사 (앞으로 이동)
        GetComponent<Rigidbody>().velocity = transform.right * bulletSpeed;

        // 일정 시간 후에 총알 제거 (예: 10초 후)
        Destroy(gameObject, 10f);
    }
}
